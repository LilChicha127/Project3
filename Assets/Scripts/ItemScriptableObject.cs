using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "Gameplay/Weapon")]
public class ItemScriptableObject : ScriptableObject
{
    
    [SerializeField] public GameObject _prefab;
    [SerializeField] private Sprite _sprite;
    [SerializeField] public int indexForAW;
    
}
