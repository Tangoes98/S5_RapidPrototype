using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class LanguageData
{
    public static string CURRENT_LANGUAGE = "en";

    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION =
        new Dictionary<string, Dictionary<string, string>>()
        {
            {"key_play", new Dictionary<string, string>()
                {
                    {"en", "PLAY"},
                    {"fr", "JOUER"}
                }
            },
            {"key_setting", new Dictionary<string, string>()
                {
                    {"en", "SETTING"},
                    {"fr", "OPTIONS"}
                }
            },
            {"key_exit", new Dictionary<string, string>()
                {
                    {"en", "EXIT"},
                    {"fr", "QUITTER"}
                }

            },
        };



    public static string[] LANGUAGES = new string[] { "en", "fr" };


    static UnityEvent _OnLanguageChanged;
    public static UnityEvent OnLanguageChanged
    {
        get
        {
            if (_OnLanguageChanged == null)
                _OnLanguageChanged = new UnityEvent();
            return _OnLanguageChanged;
        }
    }





}
