using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    public void SpawnPlayer()
    {
        Instantiate<GameObject>(Player);
        Camera.GetComponent<CameraControllerScript>().PlayerSpawn();
    }
}
