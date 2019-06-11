using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas; public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get { return _createOrJoinRoomCanvas; } }

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas; public CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas; } }
    #endregion
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks
    private void Awake()
    {
        FirstInitialize();
    }
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods*
    #endregion
    #region Private Methods
    private void FirstInitialize()
    {
        CreateOrJoinRoomCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
    }
    #endregion
}
