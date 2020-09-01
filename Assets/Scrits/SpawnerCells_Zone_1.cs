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

    public int rowZone_0_door, collumnZone_0_door;

    public int countZone = 0;

  //  int rowZone_0_Door_1, collumnZone_0_Door_1, rowZone_0_Door_2, collumnZone_0_Door_2;

    public bool ZoneUp = false, ZoneDown = false, ZoneRight = false, ZoneLeft = false;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");

        SpawnCells();

        //List<GameObject> cellsDoors = GameController.GetComponent<GameController>().CellCorridor_zone0;
        /*
        for (int i = 0; i <= cellsDoors.Count; i++)
        {
            if (i == 0)
            {
                rowZone_0_Door_1 = cellsDoors[i].GetComponent<CellScript>().MyRow;
                collumnZone_0_Door_1 = cellsDoors[i].GetComponent<CellScript>().MyCollumn;
                // Debug.Log("Gotcha_1"  + " " +  rowZone_0_Door_1 + " " + collumnZone_0_Door_1);
                //  Debug.Log("" +  GameController.GetComponent<GameController>().Cells_zone_1[19, collumnZone_0_Door_1].name);
            }
            else if (i == 1)
            {

                rowZone_0_Door_2 = cellsDoors[i].GetComponent<CellScript>().MyRow;
                collumnZone_0_Door_2 = cellsDoors[i].GetComponent<CellScript>().MyCollumn;
                //  Debug.Log("Gotcha_2" + " " + rowZone_0_Door_2 + " " + collumnZone_0_Door_2);
            }
        }
        */
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

        Debug.Log("start");

        if(rowZone_0_door == 19)
        {

        }
        if (rowZone_0_door == 0)
        {

        }
        if (collumnZone_0_door == 19)
        {

        }
        if (collumnZone_0_door == 0)
        {

        }

        /*
                if (ZoneUp)
                {
                    Debug.Log("YES");

                    if (rowZone_0_Door_1 == 0)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[0, collumnZone_0_Door_1].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                    if (rowZone_0_Door_2 == 0)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[0, collumnZone_0_Door_2].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                }
                else if (ZoneDown)
                {
                    Debug.Log("YES");

                    if (rowZone_0_Door_1 == 19)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[19, collumnZone_0_Door_1].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");
                    }
                    if (rowZone_0_Door_2 == 19)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[19, collumnZone_0_Door_2].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                }
                else if (ZoneRight)
                {
                    Debug.Log("YES");

                    if (collumnZone_0_Door_1 == 0)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[rowZone_0_Door_1, 0].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                    if (collumnZone_0_Door_2 == 0)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[rowZone_0_Door_2, 0].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                }
                else if (ZoneLeft)
                {
                    Debug.Log("YES");

                    if (collumnZone_0_Door_1 == 19)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[rowZone_0_Door_1, 19].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                    if (collumnZone_0_Door_2 == 19)
                    {
                        GameController.GetComponent<GameController>().Cells_zone_1[rowZone_0_Door_2, 19].GetComponent<CellScript>()
                            .SetCollor(CellScript.Collors.none);
                        Debug.Log("YES");

                    }
                }
                */
    }

    
}
