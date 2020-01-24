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
    [SerializeField] SV_GameUser currentUser = new SV_GameUser();
    public float LoadingProgress => ((float) loadingStep / loadingMaxStep);
    #endregion

    #region unity methods
    IEnumerator Start()
    {
        Debug.Log(SV_BaseURL.ProfilePath);
        yield return StartCoroutine(CreateGameEnvironment());
        loadingStep++; 
    }
    #endregion

    #region custom methods
    IEnumerator CreateGameEnvironment()
    {
        bool _userExis = Directory.Exists(currentUser.UserFolder);

        if (!_userExis)
        {
            Directory.CreateDirectory(currentUser.UserFolder);
            _userExis = Directory.Exists(currentUser.UserFolder);
            if(!_userExis) yield break;
        }

        loadingStep++;
        OnLoadingProgress?.Invoke(LoadingProgress);
        
    }
    #endregion
    // Start is called before the first frame update

}

