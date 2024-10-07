using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraMovement cam;
    private void Update()
    {
        cam.CameraLogic();
    }
}
