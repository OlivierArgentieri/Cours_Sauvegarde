using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class SV_GameData : MonoBehaviour
{
    #region f/p
    public event Action<float> OnLoadingProgress = null;
    
    private int loadingStep = 0;
    private int loadingMaxStep = 4;
    [SerializeField] SV_GameUser currentUser = new SV_GameUser();
    [SerializeField] List<SV_GameUser> allGameUsers = new List<SV_GameUser>();
    [SerializeField, Range(0,100)] float progress = 0;
    [SerializeField] private Transform playerTransform = null;

    public float LoadingProgress => (progress = (float) loadingStep / loadingMaxStep);
    #endregion

    #region unity methods

    private void Awake()
    {
        OnLoadingProgress += ShowProgress;
    }

    IEnumerator Start()
    {
        yield return StartCoroutine(CreateGameEnvironment());
        yield return StartCoroutine(getAllGameUsers(SV_BaseURL.ProfilePath));
        if(allGameUsers.Count == 0) yield break;
        yield return StartCoroutine(CreateUserEnvironment(allGameUsers[0]));
        yield return StartCoroutine(LoadSave(currentUser.UserSave, playerTransform));
        
        yield return new WaitForSeconds(5);
        currentUser.SaveUser();
        
    }

    private void OnDestroy()
    {
        OnLoadingProgress -= ShowProgress;
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
    
    IEnumerator CreateUserEnvironment(SV_GameUser _user)
    {
        if (_user == null) yield break;
        
        bool _saveExists = File.Exists(_user.UserSave);
        if (!_saveExists)
        {
            File.WriteAllText(_user.UserSave, SV_BaseData.Base);
            _saveExists = File.Exists(_user.UserSave);

            if(!_saveExists)
                yield break;
        }

        string[] _content = File.ReadAllLines(_user.UserSave);



        if(_content == null || _content.Length == 0 )
            File.WriteAllText(_user.UserSave, SV_BaseData.Base);
        loadingStep++;
        OnLoadingProgress?.Invoke(LoadingProgress);
    }

    IEnumerator getAllGameUsers(string _gameProfilesFolder)
    {
        string[] _allPath = Directory.GetDirectories(_gameProfilesFolder);
        string[] _userNames = _allPath.Select(p => Path.GetFileName(p)).ToArray();
        
        allGameUsers.Clear();
        _userNames.ToList().ForEach(u => allGameUsers.Add(new SV_GameUser(u)));
        yield return new WaitForEndOfFrame();
        loadingStep++;
        OnLoadingProgress?.Invoke(LoadingProgress);
    }

    IEnumerator LoadSave(string _currentSave, Transform playerTrnasform)
    {
        if(String.IsNullOrEmpty(_currentSave)) yield break;
        SV_SaveData _save = new SV_SaveData(_currentSave);
        currentUser.SetCurrentSave(_save, playerTrnasform);
        loadingStep++;
        OnLoadingProgress?.Invoke(LoadingProgress);
    }

    void ShowProgress(float _gameProfilesFolder)
    {
        
    }
    #endregion
}

