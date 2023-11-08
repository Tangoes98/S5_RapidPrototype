using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ProtoSerializeDictionary : MonoBehaviour
{
    public SerializeDictionaryElement[] ProtoSerializedDictionary;

    public ProtoDictionary<int, string> p_dictionary = new();


    Dictionary<string, int> _dictionary;

    [Serializable]
    public struct SerializeDictionaryElement
    {
        public string TextString;
        public int IntValue;
    }

    void Start()
    {
        _dictionary = new();

        UpdateSerializedDictionary();

        // Debug.Log(_dictionary["FirstItem"]);
        // Debug.Log(_dictionary["SecondItem"]);
        // Debug.Log(_dictionary.ElementAt(0).Key);

        //p_dictionary.Dictionary().Remove(p_dictionary.Dictionary().ElementAt(0).Key);

        // p_dictionary.UpdateDictionary();

        p_dictionary.Add(3, "ThirdItem");
        //p_dictionary.Remove(3,"ThirdItem");

        Debug.Log(p_dictionary.Dictionary()[3]);

    }

    void UpdateSerializedDictionary()
    {
        foreach (SerializeDictionaryElement item in ProtoSerializedDictionary)
        {
            _dictionary.Add(item.TextString, item.IntValue);
        }
    }
}
