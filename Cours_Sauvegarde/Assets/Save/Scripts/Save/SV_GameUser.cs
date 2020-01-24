using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SV_GameUser
{
    #region f/p
    [SerializeField] private string userPseudo = "Nunutte";
    [SerializeField] private SV_SaveData currentSave = null;
    [SerializeField] SV_ProfileData profileData = new SV_ProfileData();

    
    public string UserPseudo => userPseudo;
    public string UserFolder => Path.Combine(SV_BaseURL.ProfilePath, UserPseudo);
    public string UserSave => Path.Combine(SV_BaseURL.ProfilePath, UserPseudo, "save.zob");

    #endregion


    #region constructor

    
    public SV_GameUser(){ }

    public SV_GameUser(string _userPseudo)
    {
        userPseudo = _userPseudo;
    }
    #endregion

    public void SaveUser()
    {
        if (!Directory.Exists(UserFolder))  return;
        if (!File.Exists(UserSave))  return;
        
        File.WriteAllText(UserSave, profileData.SaveData());
    }
    
    public void SetCurrentSave(SV_SaveData _save, Transform _playerTransform)
    {
        currentSave = _save;
        profileData.LoadSettings(_save, _playerTransform);
    }
}