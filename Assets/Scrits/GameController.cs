using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject[,] Cells = new GameObject[20, 20];

    public List<GameObject> CellCorridor;


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int r = Random.Range(0, 20);
            int c = Random.Range(0, 20);
            Debug.Log(Cells[r, c].name);
        }
    }


}