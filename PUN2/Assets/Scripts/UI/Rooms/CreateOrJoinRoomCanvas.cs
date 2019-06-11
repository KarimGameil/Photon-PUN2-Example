using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingsMenu _roomListingMenu;
    #endregion
    private RoomsCanvases _roomsCanvases;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingMenu.FirstInitialize(canvases);
    }
    #endregion
    #region Private Methods*
    #endregion
}
