using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab
{
    #region Public Variables
    public GameObject Prefab;
    public string Path;
    #endregion
    #region Private Variables*
    #endregion
    #region Constructors
    public NetworkedPrefab(GameObject obj, string path)
    {
        Prefab = obj;
        Path = ReturnPrefabPathModified(path);
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
    #region Private Methods
    private string ReturnPrefabPathModified(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");
        if (startIndex==-1)
        {
            return string.Empty;
        }
        else
        {
            return path.Substring(startIndex+additionalLength, path.Length - (additionalLength+startIndex + extensionLength));
        }
    }
    #endregion
}
