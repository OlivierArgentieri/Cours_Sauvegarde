using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SV_ProfileData
{
    #region f/p
    [SerializeField] private SV_GameSettingsSaveData settings = new SV_GameSettingsSaveData();
    [SerializeField] private SV_PlayerSaveData playerData = new SV_PlayerSaveData();

   

    #endregion


    #region custom methods

    public void LoadSettings(SV_SaveData _save, Transform playerTransform)
    {
        settings.Load(_save);
        playerData.PlayerTransform = playerTransform;
        playerData.Load(_save);
    }

    public string SaveData()
    {
        string _data = settings.ToString();
        _data += playerData.ToString();
        return _data;
    }
    #endregion
}
