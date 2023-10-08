using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAbility
{
    public enum PlayerAttributes
    {
        FIRE, WATER, LIGHT, FOREST, SWAMP

    }

    [SerializeField] PlayerAttributes _playerAttributes;
    [SerializeField] int _abilityLevel;


}
