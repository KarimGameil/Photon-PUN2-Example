using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OwnershipTransfer : MonoBehaviourPun,IPunOwnershipCallbacks
{
    #region Public Variables*
    #endregion
    #region Private Variables*
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks
    private void Awake()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnMouseDown()
    {
        base.photonView.RequestOwnership();
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    #endregion
    #region IPunOwnershipCallbacks
    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != base.photonView)
        {
            return;
        }

        //Add Checks&Conditions Here..

        base.photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView != base.photonView)
        {
            return;
        }
    }
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods*
    #endregion
    #region Private Methods*
    #endregion
}
