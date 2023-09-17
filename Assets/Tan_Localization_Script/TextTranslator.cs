using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.Common;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslator : MonoBehaviour
{
    TextMeshProUGUI _text;
    string _key;
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _key = _text.text;

        SetText();
        LanguageData.OnLanguageChanged.AddListener(SetText);
    }

    void SetText()
    {
        _text.text = LanguageData.LOCALIZATION[_key][LanguageData.CURRENT_LANGUAGE];

    }
}
