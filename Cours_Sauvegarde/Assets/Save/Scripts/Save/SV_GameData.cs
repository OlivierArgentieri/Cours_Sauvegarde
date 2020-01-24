using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SV_GameData : MonoBehaviour
{
    #region f/p
    public event Action<float> OnLoadingProgress = null;
    
    private int loadingStep = 0;
    private int loadingMaxStep = 1;
    [SerializeField] SV_ProfileData profileData = new SV_ProfileData();

    public float LoadingProgress => ((float) loadingStep / loadingMaxStep);
    
    #endregion

    IEnumerator Start()
    {
        Debug.Log(SV_BaseURL.ProfilePath);
        yield return StartCoroutine(CreateGameEnvironment());
        loadingStep++; 
        OnLoadingProgress?.Invoke(LoadingProgress);

    }
    #region unity methods
    #endregion

    #region custom methods

    IEnumerator CreateGameEnvironment()
    {
        bool _userExis = Directory.Exists(SV_BaseURL.ProfilePath);

        if (!_userExis)
            Directory.CreateDirectory(SV_BaseURL.ProfilePath);
        _userExis = Directory.Exists(SV_BaseURL.ProfilePath);
        
        if(!_userExis) yield break;
        
    }
    #endregion
    // Start is called before the first frame update

}

