using System;

[Serializable]
public static class SV_BaseData 
{
    #region f/p

    public static string Base
    {
        get => "[CONFIG]\n"
        + "screen_width=1920\n"
        + "screen_height=1080\n"
        + "fullscreen=1\n\n"
        + "[PLAYER]\n"
        + "x=0\n"
        + "y=0\n"
        + "z=0\n"
        ;
    }

    #endregion
}
