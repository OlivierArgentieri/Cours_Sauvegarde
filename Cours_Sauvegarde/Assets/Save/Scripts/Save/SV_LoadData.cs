using UnityEngine;

public abstract class SV_LoadData
{
    #region f/p
    protected abstract string Header { get; }
    protected abstract  string Title { get; }
    #endregion
    
    
    
    #region custom methods
    public virtual void Load(SV_SaveData _save)
    {
        int _startConfig = 0;
        int _endConfig = 0;
        string[] _allLines = _save.Data.Split('\n');
        for (int i = 0; i < _allLines.Length; i++)
        {
            string _value = _allLines[i].ToLower();
            if (_value.Equals(Header.ToLower()))
                _startConfig = i;
            if (i == _allLines.Length - 1)
            {
                _endConfig = i;
                break;
            }
            else if (_value.Contains("[") && !_value.Contains(Title.ToLower()) && !string.IsNullOrEmpty(_value))
            {
                _endConfig = i;
                break;
            }
        }
        LoadValues(_allLines, _startConfig, _endConfig);
    }

  protected virtual void LoadValues(string[] _lines, int _from, int _to)
    {
        for (int i = _from + 1; i < _to; i++)
        {
            string _data = _lines[i].ToLower().Trim();
            if (string.IsNullOrEmpty(_data)) continue;

            if (_data.Contains("=") && _data.Split('=').Length == 2)
            {
                ApplyData(_data.Split('=')[0], _data.Split('=')[1]);
            }
        }
    }
    protected abstract void ApplyData(string _param, string _value);

    #endregion
}