using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject _playerGo;
    public Transform TransformPlayer;
    private void Awake()
    {
     
        GameObject player = Instantiate(_playerGo,TransformPlayer.position,Quaternion.identity);
    }
}
