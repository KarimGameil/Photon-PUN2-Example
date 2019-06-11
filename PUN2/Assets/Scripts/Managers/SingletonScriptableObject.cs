using UnityEngine;

public class SingletonScriptableObject<T>:ScriptableObject where T:ScriptableObject
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region static
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> result.Length is 0 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> result.Length is greater than 1 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                _instance = results[0];
            }
            return _instance;
        }
    }
    #endregion
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
