using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public GameObject Player;


    private void Update()
    {
        if(Player != null)
           transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }

    public void PlayerSpawn()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
