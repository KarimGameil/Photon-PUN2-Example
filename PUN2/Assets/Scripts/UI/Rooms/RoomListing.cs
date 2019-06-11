using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomListing : MonoBehaviourPunCallbacks
{

    #region Public Variables
    public RoomInfo RoomInfo { get; private set; }
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Text _roomListingText;
    #endregion
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    #region OnClick Methods
    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
    #endregion
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _roomListingText.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
    
    #endregion
    #region Private Methods*
    #endregion
}
