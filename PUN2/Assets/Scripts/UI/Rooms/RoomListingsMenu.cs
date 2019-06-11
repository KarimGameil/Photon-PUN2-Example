using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;//Assing the prefab, not the instance
    #endregion
    private List<RoomListing> _listings=new List<RoomListing>();//Keep track of the instantiated RoomListings

    private RoomsCanvases _roomsCanvases;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("ROOMLIST LENGTH:" + roomList.Count);
        foreach (RoomInfo info in roomList)
        {
            //Removed from rooms list
            if (info.RemovedFromList)
            {
                RemoveRoomListing(info);
            }
            //Added to rooms list
            else
            {
                AddRoomListing(info);
            }
        }
    }
    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomCanvas.Show();
        _content.DestroyChildren();
        _listings.Clear();
    }
    #endregion
    #endregion
    #region Public Methods
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }
    #endregion
    #region Private Methods
    private void AddRoomListing(RoomInfo info)
    {
        int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);//x is some element in the _listings list.
        if (index==-1)
        {
            RoomListing listing = Instantiate(_roomListing, _content);
            if (listing != null)
            {
                listing.SetRoomInfo(info);//Update the text on the Room Listing
                _listings.Add(listing);
            }
        }        
    }
    private void RemoveRoomListing(RoomInfo info)
    {
        int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);//x is some element in the _listings list.
        print("MATCH FOUND AT INDEX:" + index.ToString());
        //In case there's a matching element.
        if (index != -1)
        {
            //MATCH FOUND!

            Destroy(_listings[index].gameObject);//Remove the RoomListing instance whose RoomListing script matches the one removed from the room list.
            _listings.RemoveAt(index);//Update the list to keep track of the latest state
        }
    }
    #endregion
}
