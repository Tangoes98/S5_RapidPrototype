using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "RapidPrototype/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] string _name;

    [Space(10)]
    [SerializeField] int _level;
    [SerializeField] float _exp;

    [Space(10)]
    [SerializeField][Range(0, 20)] int _strength;
    [SerializeField][Range(0, 20)] int _dexterity;
    [SerializeField][Range(0, 20)] int _constitution;
    [SerializeField][Range(0, 20)] int _intelligence;
    [SerializeField][Range(0, 20)] int _wisdom;
    [SerializeField][Range(0, 20)] int _charisma;

    [Space(10)]
    [SerializeField] int _bonus;
    [SerializeField] int _speed;



    public string Name { get { return _name; } }
    public int Level { get { return _level; } }
    public float Exp { get { return _exp; } }
    public int Strength { get { return _strength; } }
    public int Dexterity { get { return _dexterity; } }
    public int Constitution { get { return _constitution; } }
    public int Intelligence { get { return _intelligence; } }
    public int Wisdom { get { return _wisdom; } }
    public int Charisma { get { return _charisma; } }
}
