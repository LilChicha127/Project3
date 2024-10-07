using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    
    public void Damage(int damage);
    public void Hit();
    public void Shoot();
}
