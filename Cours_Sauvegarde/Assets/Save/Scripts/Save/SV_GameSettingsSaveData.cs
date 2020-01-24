using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class SV_GameSettingsSaveData : SV_LoadData
{
    #region f/p

    protected override string Header => "[CONFIG]";
    protected override string Title => "config";
    
    private const string ScreenWidth = "screen_width";
    private const string ScreenHeight = "screen_height";
    private const string FullScreen = "full_screen";
    private const string finalX = "x";
    private const string Y = "y";
    private const string Z = "z";

    private int finalWidth = 0;
    private int finalHeight = 0;
    private bool finalFullScreen = false;

    #endregion
    
    protected override void LoadValues(string[] _lines, int _from, int _to)
    {
        base.LoadValues(_lines, _from, _to);
        Screen.SetResolution(finalWidth, finalHeight, finalFullScreen);
    }

    protected override void ApplyData(string _param, string _value)
    {
        bool _convert = false;
        switch (_param)
        {
            case ScreenWidth:
                _convert = int.TryParse(_value, out int _width);
                finalWidth = _convert ? _width : 1920;
                break;

            case ScreenHeight:
                _convert = int.TryParse(_value, out int _height);
                finalHeight = _convert ? _height : 1080;
                break;

            case FullScreen:
                _convert = int.TryParse(_value, out int _fullscreenTest);
                finalFullScreen = _convert && _fullscreenTest == 1;
                break;
        }
    }

    public override string ToString()
    {
        string _data = $"{Title}\n"
                       + $"{ScreenWidth} = {Screen.width}\n"
                       + $"{ScreenWidth} = {Screen.height}\n"
                       + $"{FullScreen} = {(Screen.fullScreen ? 0:1)}\n";
        return _data;
    }
}