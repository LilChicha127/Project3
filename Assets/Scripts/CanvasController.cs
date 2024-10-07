using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public CanvasUpdater CanvasUpdater;


    private void Update()
    {
       
        CanvasUpdater.bullUpdate();
    }
}
