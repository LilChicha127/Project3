using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeapons : MonoBehaviour
{
    public List<GameObject> weapons;
    private void Awake()
    {
        weapons[Tempik.chaseWeapon].gameObject.SetActive(true);
    }
}
