using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu; public LeaveRoomMenu LeaveRoomMenu { get { return _leaveRoomMenu; } }
    #endregion
    private RoomsCanvases _roomsCanvases;
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    #endregion
    #region Private Methods*
   
    #endregion
}
