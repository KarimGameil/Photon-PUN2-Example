using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{

    #region Public Variables
    public Player Player { get; private set; }
    public bool Ready = false;
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Text _playerListingText;
    #endregion
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result= (int)player.CustomProperties["RandomNumber"];
        }       
        _playerListingText.text =result.ToString()+", "+ player.NickName;
    } 
    #endregion
    #region Private Methods*
    #endregion
}
