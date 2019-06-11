using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoomMenu : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    private RoomsCanvases _roomsCanvases;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    #region OnClick Methods
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomsCanvases.CurrentRoomCanvas.Hide();
    }
    #endregion
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;        
    }
    #endregion
    #region Private Methods*
    #endregion
}
