using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCellsScript_Zone_0 : MonoBehaviour
{
    [SerializeField] int CellCount = 400;
    public GameObject CellPref;
    GameObject GameController;
    public GameObject Player;

    public List<GameObject> CellCorridor_zone0 = new List<GameObject>();

    public int row_Door_1, collumn_Door_1, row_Door_2, collumn_Door_2;

    public GameObject ZonePref;

    public bool ZoneUp, ZoneDown, ZoneRight, ZoneLeft;

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");

      //  CheckZone();

        SpawnCells();

        SpawnEnemyZone();

        StartCoroutine("SpawnDoors_zone_0");

        StartCoroutine("SpawnZones");
    }

    private void SpawnCells()
    {
        int count = 1;

        int cellRowCount = CellCount / 20 - 1;
        int cellColumnCount = CellCount / 20 - 1;


        for (int row = 0; row <= cellRowCount; row++)
        {
            for (int collumn = 0; collumn <= cellColumnCount; collumn++)
            {
                GameObject tmpcell = Instantiate<GameObject>(CellPref);
                tmpcell.GetComponent<CellScript>().MyRow = row;
                tmpcell.GetComponent<CellScript>().MyCollumn = collumn;

                GameController.GetComponent<GameController>().Cells_zone_0[row, collumn] = tmpcell;

                tmpcell.transform.SetParent(this.transform, false);


                if (row == 0 || row == 19 || collumn == 0 || collumn == 19)
                {
                    tmpcell.GetComponent<CellScript>().SetCollor(CellScript.Collors.wall);
                }
                if (row == 2 && collumn == 2)
                {
                    StartCoroutine("SpawnPlayer", tmpcell);

                }

                tmpcell.name = ("zone0_" + row + collumn);


                count++;
            }
        }
    }

    private void SpawnEnemyZone()
    {
        int randomRow = Random.Range(1, 18);
        int randomColumn = Random.Range(1, 18);

        GameController.GetComponent<GameController>().Cells_zone_0[randomRow, randomColumn].
            GetComponent<CellScript>().SetCollor(CellScript.Collors.enemy);
    }

    IEnumerator SpawnDoors_zone_0()
    {
        yield return new WaitForSeconds(0.5f);

        //0 - horizontal, 
        //1 - vertical;
        int sideOfDoor_1 = Random.Range(0, 2);
        int sideOfDoor_2 = Random.Range(0, 2);

        //horizontal = 0 - up
        //horizontal = 1 - down
        //vertical = 0 - right
        //vertical = 1 - left
        int Horizontal = Random.Range(0, 2);
        int Vertical = Random.Range(0, 2);


        int cellCorridorToNextZone_1 = Random.Range(1, 18);
        int cellCorridorToNextZone_2 = Random.Range(1, 18);

        //vertical
        if (sideOfDoor_1 == 1)
        {
            //left
            if (Vertical == 1)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_1, 0].
                    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_1 = cellCorridorToNextZone_1;
                collumn_Door_1 = 0;

                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_1, 0]);
            }

            //right
            if (Vertical == 0)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_1, 19].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_1 = cellCorridorToNextZone_1;
                collumn_Door_1 = 19;

                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_1, 19]);
            }

        }

        //horizontal
        else if (sideOfDoor_1 == 0)
        {
            //down
            if (Horizontal == 1)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[0, cellCorridorToNextZone_1].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_1 = 0;
                collumn_Door_1 = cellCorridorToNextZone_1;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[0, cellCorridorToNextZone_1]);
            }

            //up
            if (Horizontal == 0)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[19, cellCorridorToNextZone_1].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_1 = 19;
                collumn_Door_1 = cellCorridorToNextZone_1;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[19, cellCorridorToNextZone_1]);
            }
        }

        //vertical
        if (sideOfDoor_2 == 0)
        {
            //left
            if (Horizontal == 1)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[0, cellCorridorToNextZone_2].
GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_2 = 0;
                collumn_Door_2 = cellCorridorToNextZone_2;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[0, cellCorridorToNextZone_2]);
            }

            //right
            if (Horizontal == 0)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[19, cellCorridorToNextZone_2].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_2 = 19;
                collumn_Door_2 = cellCorridorToNextZone_2;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[19, cellCorridorToNextZone_2]);
            }
        }

        //horizontal
        else if (sideOfDoor_2 == 1)
        {

            //down
            if (Vertical == 1)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_2, 0].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_2 = cellCorridorToNextZone_2;
                collumn_Door_2 = 0;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_2, 0]);
            }

            //up
            if (Vertical == 0)
            {
                GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_2, 19].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                row_Door_2 = cellCorridorToNextZone_2;
                collumn_Door_2 = 19;
                CellCorridor_zone0.Add(GameController.GetComponent<GameController>().Cells_zone_0[cellCorridorToNextZone_2, 19]);
            }
        }

    }

    IEnumerator SpawnPlayer(GameObject tmpcell)
    {
        yield return new WaitForSeconds(0.5f);

        GameObject tmpPlayer = Instantiate<GameObject>(Player);
        tmpPlayer.transform.position = new Vector3(tmpcell.transform.position.x, tmpcell.transform.position.y, tmpPlayer.transform.position.z);
        Camera.main.GetComponent<CameraControllerScript>().PlayerSpawn();
    }

    IEnumerator SpawnZones()
    {
        yield return new WaitForSeconds(0.6f);


      //  List<GameObject> tmpDoors = GameController.GetComponent<GameController>().CellCorridor_zone0;

        int count = 0;

        foreach(GameObject tmpDoor in CellCorridor_zone0)
        {
            if(count == 0)
            {
                //up
                if (tmpDoor.GetComponent<CellScript>().MyRow == 19 && !ZoneUp)
                {
                    ZoneUp = true;
                    //   Debug.Log("Up");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_0");
                    tmpZone.transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneDown = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_1;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_1;

                }
                //down
                else if (tmpDoor.GetComponent<CellScript>().MyRow == 0 && !ZoneDown)
                {
                    ZoneDown = true;

                    //   Debug.Log("Down");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_0");
                    tmpZone.transform.position = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneUp = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_1;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_1;

                }
                // right
                else if (tmpDoor.GetComponent<CellScript>().MyCollumn == 19 && !ZoneRight)
                {
                    ZoneRight = true;

                    //   Debug.Log("right");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_0");
                    tmpZone.transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneLeft = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_1;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_1;

                }
                //left
                else if (tmpDoor.GetComponent<CellScript>().MyCollumn == 0 && !ZoneLeft)
                {
                    ZoneLeft = true;

                    // Debug.Log("left");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_0");
                    tmpZone.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneRight = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_1;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_1;

                }
            }

            else if(count == 1)
            {
                //up
                if (tmpDoor.GetComponent<CellScript>().MyRow == 19 && !ZoneUp)
                {
                    ZoneUp = true;
                    //   Debug.Log("Up");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_1");
                    tmpZone.transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneDown = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().countZone = 1;

                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_2;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_2;

                }
                //down
                else if (tmpDoor.GetComponent<CellScript>().MyRow == 0 && !ZoneDown)
                {
                    ZoneDown = true;

                    //   Debug.Log("Down");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_1");
                    tmpZone.transform.position = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneUp = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().countZone = 1;

                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_2;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_2;

                }
                // right
                else if (tmpDoor.GetComponent<CellScript>().MyCollumn == 19 && !ZoneRight)
                {
                    ZoneRight = true;

                    //   Debug.Log("right");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_1");
                    tmpZone.transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneLeft = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().countZone = 1;

                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_2;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_2;

                }
                //left
                else if (tmpDoor.GetComponent<CellScript>().MyCollumn == 0 && !ZoneLeft)
                {
                    ZoneLeft = true;

                    // Debug.Log("left");
                    GameObject tmpZone = Instantiate<GameObject>(ZonePref);
                    tmpZone.name = ("Zone_1_1");
                    tmpZone.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().ZoneRight = true;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().countZone = 1;

                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().rowZone_0_door = row_Door_2;
                    tmpZone.GetComponentInChildren<SpawnerCells_Zone_1>().collumnZone_0_door = collumn_Door_2;

                }
            }


            count++;
        }

    }

}
