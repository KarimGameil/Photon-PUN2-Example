using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    #region Public Variables*
    #endregion
    #region Private Variables
    TextMesh TextMesh = new TextMesh();
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks
    private void Awake()
    {
        //Connect to Master server
        PhotonNetwork.AutomaticallySyncScene = true;//Not type in future videos
        PhotonNetwork.SendRate = 20;//Default=20
        PhotonNetwork.SerializationRate = 5;//Default=10
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    #endregion
    #region PUN Callbacks
    public override void OnConnectedToMaster()
    {
        print("CONNECTED TO MASTER");
        print("Local Player Name:" + PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("DISCONNECTED! " + cause.ToString());
    }
    public override void OnJoinedLobby()
    {
        print("LET'S ALL GO TO THE LOOOBBY!");
    }

    #endregion
    #endregion
    #region Public Methods*
    #endregion
    #region Private Methods*
    #endregion
}
