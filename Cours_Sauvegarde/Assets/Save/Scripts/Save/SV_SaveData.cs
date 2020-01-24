using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SV_SaveData
{
    #region f/p
    [SerializeField, TextArea] private string data = "";
    public string Data => data;
    #endregion

    
    #region constructor
    public SV_SaveData(string _filePath)
    {
        if(!File.Exists(_filePath)) return;
        data = File.ReadAllText(_filePath);
    }
    #endregion
}