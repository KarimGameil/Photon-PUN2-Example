using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Text _roomName;
    #endregion
    private RoomsCanvases _roomsCanvases;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks
    public override void OnCreatedRoom()
    {
        print("ROOM:" + _roomName.text + " WAS CREATED SUCCESSFULLY!");
        //Show the CurrentRoomCanvas
        _roomsCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("FAILED TO CREATE ROOM:" + _roomName.text + "For REASON:" + message);
    }
    #endregion
    #endregion
    #region Public Methods
    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            print("Not Connected Yet!!");
            return;
        }
        RoomOptions roomOptions = new RoomOptions {MaxPlayers=4 };
        if (_roomName.text==null)
        {
            Debug.LogError("CreateRoomMenu Script: MISSING REFERENCE TO Room Name or ROOMNAMEINPUT NOT ENTERED!, PLEASE REFER TO THE RoomName In the Inspector or ENTER THE ROOM NAME");
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(_roomName.text, roomOptions, TypedLobby.Default);

        }
    }
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }
    #endregion
    #region Private Methods*
    #endregion
}
