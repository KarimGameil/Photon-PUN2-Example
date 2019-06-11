using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu (menuName ="Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private GameSettings _gameSettings; public static GameSettings GameSettings { get { return Instance._gameSettings; } }

    [SerializeField]
    private List<NetworkedPrefab> _networkedPrefabs = new List<NetworkedPrefab>();
    #endregion
    #endregion
    #region Callbacks*
    #region MonoBehaviour Callbacks*
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods
    #region Static
    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach (NetworkedPrefab networkedPrefab in Instance._networkedPrefabs)
        {
            if (networkedPrefab.Prefab == obj)
            {
                if (networkedPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError("PATH IS EMPTY FOR GAMEOBJECT:" + networkedPrefab.Prefab);
                    return null;
                }
            }
        }
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkedPrefabs()
    {

#if UNITY_EDITOR
        Instance._networkedPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance._networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
            }
        }
#endif
    }
    #endregion
    #endregion
    #region Private Methods*
    #endregion
}
