using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class CameraMovement : MonoBehaviour, ICamera
{
    public float mouseSensitivity;
    public Transform _player;
    public float sensitivity = 100.0f;
    public float smoothing = 2.0f;
    Vector2 mouseLook;
    Vector2 smoothV;
    


    [SerializeField] private float _verticalLover;
    [SerializeField] private float _verticalUpper;
    private float _currentVerticalAngle;

  
   
    private void Start()
    {
        _player = FindAnyObjectByType<Character>().GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    public void CameraLogic()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        _player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, _player.transform.up);
    }
}


