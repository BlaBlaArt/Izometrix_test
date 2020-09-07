using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCells_Zone_1 : MonoBehaviour
{
    [SerializeField] int CellCount = 400;
    public GameObject CellPref;
    GameObject GameController;

    public GameObject ZonePref;
    [SerializeField] int row;

    public int rowZone_0_door
    {
        set
        {
            row = value;
            if (row == 19)
            {
                row = 0;
            }
            else if (row == 0)
            {
                row = 19;
            }
        }
        get
        {
            return row;
        }
    }
    [SerializeField] int col;

    public int collumnZone_0_door
    {
        set
        {
            col = value;
            if (col == 19)
            {
                col = 0;
            }
            else if (col == 0)
            {
                col = 19;
            }
        }
        get
        {
            return col;
        }
    }

    public int countZone = 0;

  //  int rowZone_0_Door_1, collumnZone_0_Door_1, rowZone_0_Door_2, collumnZone_0_Door_2;

    public bool ZoneUp = false, ZoneDown = false, ZoneRight = false, ZoneLeft = false;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");

        SpawnCells();


        StartCoroutine("SpawnDoors_zone_1");
    }

    private void SpawnCells()
    {


        int cellRowCount = CellCount / 20 - 1;
        int cellColumnCount = CellCount / 20 - 1;


        for (int row = 0; row <= cellRowCount; row++)
        {
            for (int collumn = 0; collumn <= cellColumnCount; collumn++)
            {
                GameObject tmpcell = Instantiate<GameObject>(CellPref);
                tmpcell.GetComponent<CellScript>().MyRow = row;
                tmpcell.GetComponent<CellScript>().MyCollumn = collumn;

                if(countZone == 0)
                {
                    GameController.GetComponent<GameController>().Cells_zone_1_0[row, collumn] = tmpcell;
                }
                else if(countZone == 1)
                {
                    GameController.GetComponent<GameController>().Cells_zone_1_1[row, collumn] = tmpcell;
                }

                tmpcell.transform.SetParent(this.transform, false);


                if (row == 0 || row == 19 || collumn == 0 || collumn == 19)
                {
                    tmpcell.GetComponent<CellScript>().SetCollor(CellScript.Collors.wall);
                }

                if (countZone == 0)
                {
                    tmpcell.name = ("zone1_" + row + collumn);

                }
                else if (countZone == 1)
                {
                    tmpcell.name = ("zone1_" + row + collumn);

                }


            }
        }
    }

    IEnumerator SpawnDoors_zone_1()
    {
        yield return new WaitForSeconds(1);


        if(countZone == 0)
        {
            GameController.GetComponent<GameController>().Cells_zone_1_0[rowZone_0_door, collumnZone_0_door].
                GetComponent<CellScript>().SetCollor(CellScript.Collors.none);
        }

        if (countZone == 1)
        {
            GameController.GetComponent<GameController>().Cells_zone_1_1[rowZone_0_door, collumnZone_0_door].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);
        }
    }

    
}
