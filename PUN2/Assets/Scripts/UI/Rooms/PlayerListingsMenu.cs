using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;//Assigning the prefab, not the instance
    [SerializeField]
    private Text _readyUpText;
    #endregion
    private RoomsCanvases _roomsCanvases;

    private List<PlayerListing> _listings = new List<PlayerListing>();//Keep track of the instantiated PlayerListings

    private bool _ready=false;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemovePlayerListing(otherPlayer);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SetReadyUp(false);
        GetCurrentRoomPlayers();
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listings.Count; i++)
        {
            Destroy(_listings[i].gameObject);
        }
        _listings.Clear();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }
    #endregion
    #endregion
    #region Public Methods
    #region OnClick Methods
    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            /*for (int i = 0; i < _listings.Count; i++)
            {
                if (_listings[i].Player!=PhotonNetwork.LocalPlayer)
                {
                    if (!_listings[i].Ready)
                    {
                        return;
                    }
                }
            }*/

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }
    public void OnClick_ReadyUP()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!_ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
        }
    }
    #endregion
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }  
    #endregion
    #region Private Methods
    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        if (PhotonNetwork.CurrentRoom==null|| PhotonNetwork.CurrentRoom.Players==null)
        {
            return;
        }
        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player)
    {
        int index = _listings.FindIndex(x => x.Player == player);//x is some element in the _listings list.
        if (index!=-1)
        {
            _listings[index].SetPlayerInfo(player);//Just update it if it exists
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);//Update the text on the Room Listing
                _listings.Add(listing);
            }
        }
        
    }
    private void RemovePlayerListing(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);//x is some element in the _listings list.
        print("MATCH FOUND AT INDEX:" + index.ToString());
        //In case there's a matching element.
        if (index != -1)
        {
            //MATCH FOUND!

            Destroy(_listings[index].gameObject);//Remove the PlayerListing instance whose PlayerListing script matches the one removed from the room list.
            _listings.RemoveAt(index);//Update the list to keep track of the latest state
        }
    }
    private void SetReadyUp(bool ready)
    {       
        _ready = ready;
        if (!ready)
        {
            _readyUpText.text = "NOT READY";
            _readyUpText.color = Color.red;
        }
        else
        {
            _readyUpText.text = "READY";
            _readyUpText.color = new Color(0f, 159 / 255f, 159 / 255f,1f);
        }
    }
    #region RPC Methods
    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].Ready = ready;
        }
    }
    #endregion

    #endregion
}
