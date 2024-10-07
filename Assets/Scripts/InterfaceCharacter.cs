using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceCharacter 
{
    
    public void Move(int Speed);
    public void Jump(int power);

    
    public void Lose();
}
