using System;
using System.IO;

public static class SV_BaseURL
{

    public static string ProfileFolder => "GameUser"; 
    public static string ProfilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ProfileFolder);
}