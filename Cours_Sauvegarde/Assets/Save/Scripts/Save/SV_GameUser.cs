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

    #endregion


}