using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private GameObject _prefab;
    #endregion
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks
    private void Awake()
    {
        MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
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
