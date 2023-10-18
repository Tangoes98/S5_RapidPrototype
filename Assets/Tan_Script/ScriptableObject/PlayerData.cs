using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "RapidPrototype/PlayerData")]
public class PlayerData : ScriptableObject
{
    public enum PlayerSkills
    {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival,
    }

    [SerializeField] string _name;


    [SerializeField] int _level;
    [SerializeField] float _exp;


    [SerializeField][Range(0, 20)] int _strength;
    [SerializeField][Range(0, 20)] int _dexterity;
    [SerializeField][Range(0, 20)] int _constitution;
    [SerializeField][Range(0, 20)] int _intelligence;
    [SerializeField][Range(0, 20)] int _wisdom;
    [SerializeField][Range(0, 20)] int _charisma;



    [SerializeField] bool _showSkills;
    [SerializeField] PlayerSkills _skills;

    [SerializeField] PlayerAbility[] _playerAbilities;


    [SerializeField] int _bonus;
    [SerializeField] int _speed;




    public string Name => _name;
    public int Level => _level;
    public float Exp => _exp;
    public int Strength => _strength;
    public int Dexterity => _dexterity;
    public int Constitution => _constitution;
    public int Intelligence => _intelligence;
    public int Wisdom => _wisdom;
    public int Charisma => _charisma;

    public bool ShowSkills => _showSkills;
    public PlayerSkills Skills => _skills;
    public PlayerAbility[] PlayerAbilities => _playerAbilities;
}

