using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum PlayerAttributes
{
    FIRE, WATER, LIGHT, FOREST, SWAMP

}


[System.Serializable]
public class PlayerAbility
{

    [SerializeField] PlayerAttributes _playerAttributes;
    [SerializeField] int _ability;


}
