using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class RandomCustomPropertyGenerator : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private Text _text;
    #endregion
    private ExitGames.Client.Photon.Hashtable _myCusomProperties = new ExitGames.Client.Photon.Hashtable();
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    #region OnClick Methods
    public void OnClick_Button()
    {
        SetCustomNumber();
    }
    #endregion
    #endregion
    #region Private Methods
    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0,99);
        _text.text = result.ToString();
        _myCusomProperties["RandomNumber"] = result;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCusomProperties;
    }
    #endregion
}
