using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SV_GameUser
{
    #region f/p
    [SerializeField] private string userPseudo = "Nunutte";

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

}