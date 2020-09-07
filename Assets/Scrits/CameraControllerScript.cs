using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public GameObject Player;

    public static bool checkPlayer = true;

    private void Update()
    {
        if (checkPlayer)
        {
            if (Player != null)
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }

    public void PlayerSpawn()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
