using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SV_PlayerSaveData : SV_LoadData
{
    #region f/p

    protected override string Header => "[PLAYER]";
    protected override string Title => string.Empty;

    const string xValue = "x";
    const string yValue = "y";
    const string zValue = "z";

    public Transform PlayerTransform { get; set; }

    private float finalX = 0;
    private float finalY = 0;
    private float finalZ = 0;

    public bool IsValid => PlayerTransform;

    #endregion


    protected override void LoadValues(string[] _lines, int _from, int _to)
    {
        base.LoadValues(_lines, _from, _to);
        if (!IsValid) return;
        PlayerTransform.position = new Vector3(finalX, finalY, finalZ);
    }

    protected override void ApplyData(string _param, string _value)
    {
        bool _convert = false;

        switch (_param)
        {
            case xValue:
                _convert = float.TryParse(_value, out float _x);
                finalX = _convert ? _x : 0;
                break;

            case yValue:
                _convert = float.TryParse(_value, out float _y);
                finalY = _convert ? _y : 0;
                break;

            case zValue:
                _convert = float.TryParse(_value, out float _z);
                finalZ = _convert ? _z : 0;
                break;
        }
    }

    public override string ToString()
    {
        string _data = $"{Title}\n"
                       + $"{xValue} = {(IsValid ? PlayerTransform.position.x : 0)}\n"
                       + $"{yValue} = {(IsValid ? PlayerTransform.position.y : 0)}\n"
                       + $"{zValue} = {(IsValid ? PlayerTransform.position.z : 0)}\n";
        return _data;
    }
}