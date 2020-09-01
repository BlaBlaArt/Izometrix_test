using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject[,] Cells_zone_0 = new GameObject[20, 20];

    public GameObject[,] Cells_zone_1_0 = new GameObject[20, 20];

    public GameObject[,] Cells_zone_1_1 = new GameObject[20, 20];




    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int r = Random.Range(0, 20);
            int c = Random.Range(0, 20);
        //    Debug.Log(Cells[r, c].name);
        }
    }


}