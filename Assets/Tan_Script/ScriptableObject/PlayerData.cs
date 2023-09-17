using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "RapidPrototype/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] int _level;
    [SerializeField] float _exp;
}
