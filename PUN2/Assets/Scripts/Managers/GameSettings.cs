using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]

public class GameSettings :ScriptableObject
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } }
    #endregion
    private string _nickName = "GETAJOB";
    public string NickName
    {
        get
        {
            int value = Random.Range(1, 9999);
            return _nickName + value.ToString();
        }
    }
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods*
    #endregion
    #region Private Methods*
    #endregion
}
