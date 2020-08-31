using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCellsScript : MonoBehaviour
{
    [SerializeField] int CellCount = 400;
    public GameObject CellPref;
    GameObject GameController;
    public GameObject Player;

    public Color zone_0col ,zone_1col, zone_2col;



    private void Awake()
    {
        CheckZone();
    }

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");

        SpawnCells();
        StartCoroutine("SpawnDoors");
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
                GameController.GetComponent<GameController>().Cells[row, collumn] = tmpcell;

                tmpcell.transform.SetParent(this.transform, false);


                if (row == 0 || row == 19 || collumn == 0 || collumn == 19)
                {
                    tmpcell.GetComponent<CellScript>().SetCollor(CellScript.Collors.wall);
                }
                if (row == 2 && collumn == 2)
                {
                    StartCoroutine("SpawnPlayer", tmpcell);
                }

                tmpcell.name = ("" + row + collumn);
                count++;
            }
        }
    }

    IEnumerator SpawnDoors()
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

        if (sideOfDoor_1 == 1)
        {
            if (Vertical == 1)
            {
                GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_1, 0].
                    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                GameController.GetComponent<GameController>().CellCorridor.Add
                    (GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_1, 0]);
            }

            if (Vertical == 0)
            {
                GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_1, 19].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                GameController.GetComponent<GameController>().CellCorridor.Add
    (GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_1, 19]);
            }

        }
        else if (sideOfDoor_1 == 0)
        {
            if (Horizontal == 1)
            {
                GameController.GetComponent<GameController>().Cells[0, cellCorridorToNextZone_2].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                GameController.GetComponent<GameController>().CellCorridor.Add
(GameController.GetComponent<GameController>().Cells[0, cellCorridorToNextZone_2]);
            }

            if (Horizontal == 0)
            {
                GameController.GetComponent<GameController>().Cells[19, cellCorridorToNextZone_2].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

                GameController.GetComponent<GameController>().CellCorridor.Add
(GameController.GetComponent<GameController>().Cells[19, cellCorridorToNextZone_2]);
            }
        }


        if (sideOfDoor_2 == 0)
        {
            if (Horizontal == 1)
            {
                GameController.GetComponent<GameController>().Cells[0, cellCorridorToNextZone_2].
GetComponent<CellScript>().SetCollor(CellScript.Collors.none);

            }

            if (Horizontal == 0)
            {
                GameController.GetComponent<GameController>().Cells[19, cellCorridorToNextZone_2].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);
            }
        }
        else if (sideOfDoor_2 == 1)
        {
            if (Vertical == 1)
            {
                GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_2, 0].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);
            }

            if (Vertical == 0)
            {
                GameController.GetComponent<GameController>().Cells[cellCorridorToNextZone_2, 0].
    GetComponent<CellScript>().SetCollor(CellScript.Collors.none);
            }
        }

    }



 /*   private void CountTranslateToZone()
    {
        int transCount = Random.Range(0, 4);
        for(int i = 0; i<=transCount; i++)
        {

        }

    }*/

    private void CheckZone()
    {
        if (GetComponentInParent<Transform>().name == "Zone_0")
        {
            GetComponent<Image>().color = zone_0col;
        }

        if (GetComponentInParent<Transform>().name == "Zone_1")
        {
            GetComponent<Image>().color = zone_1col;
        }
    }

    IEnumerator SpawnPlayer(GameObject tmpcell)
    {
        yield return new WaitForSeconds(0.5f);

        GameObject tmpPlayer = Instantiate<GameObject>(Player);
        tmpPlayer.transform.position = new Vector3(tmpcell.transform.position.x, tmpcell.transform.position.y, tmpPlayer.transform.position.z);
        Camera.main.GetComponent<CameraControllerScript>().PlayerSpawn();
    }

}
