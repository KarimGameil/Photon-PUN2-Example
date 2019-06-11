using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtTransform
{
    #region Public Varibales*
    #endregion
    #region Private Variables*
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    public static void DestroyChildren(this Transform t, bool destroyImmediately = false)
    {
        foreach (Transform child in t)
        {
            if (destroyImmediately)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }
    #endregion
    #region Private Methods*
    #endregion
}
