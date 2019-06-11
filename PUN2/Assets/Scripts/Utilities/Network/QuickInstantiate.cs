using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    #region Public Varibales*
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
        Vector2 offset = Random.insideUnitCircle * 3f;//random value between -3 and +3
        Vector3 position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);//Same depth, different locations
        MasterManager.NetworkInstantiate(_prefab, position, Quaternion.identity);
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
