#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class ResourcesPrefabPathBuilder : IPreprocessBuildWithReport
{
    #region Public Varibales
    public int callbackOrder { get { return 0; } }
    #endregion
    #region Private Variables
    #endregion
    #region MonoBehaviour Callbacks
    #endregion
    #region PUN Callbacks
    #endregion
    #region IPreprocessBuildWithReport Callbacks
    public void OnPreprocessBuild(BuildReport report)
    {
        MasterManager.PopulateNetworkedPrefabs();
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    #endregion

    
}
#endif