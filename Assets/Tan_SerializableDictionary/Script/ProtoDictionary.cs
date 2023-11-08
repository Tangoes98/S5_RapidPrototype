using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProtoDictionary<P_TKey, P_TValue>
{
    [Serializable]
    public struct P_DictionaryElement
    {
        public P_TKey PD_Key;
        public P_TValue PD_Value;
    }

    [SerializeField] List<P_DictionaryElement> PD_dictionary;
    Dictionary<P_TKey, P_TValue> _dictionary = new();



    void UpdateDictionary()
    {
        foreach (P_DictionaryElement item in PD_dictionary)
        {
            if (_dictionary.ContainsKey(item.PD_Key)) continue;
            _dictionary.Add(item.PD_Key, item.PD_Value);
        }
    }

    public Dictionary<P_TKey, P_TValue> Dictionary()
    {
        UpdateDictionary();
        return _dictionary;
    }

    public void Add(P_TKey key, P_TValue value)
    {
        P_DictionaryElement element = new();
        element.PD_Key = key;
        element.PD_Value = value;
        PD_dictionary.Add(element);

        _dictionary.Add(key, value);
    }
    public void Remove(P_TKey key, P_TValue value)
    {
        P_DictionaryElement element = new();
        element.PD_Key = key;
        element.PD_Value = value;
        PD_dictionary.Remove(element);

        _dictionary.Remove(key);
    }

}
