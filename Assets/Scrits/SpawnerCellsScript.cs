using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCellsScript : MonoBehaviour
{
    [SerializeField] int CellCount = 400;
    public GameObject CellPref;

    void Start()
    {
        for(int i = 0; i<=CellCount; i++)
        {
            GameObject tmpcell = Instantiate<GameObject>(CellPref);
            tmpcell.transform.SetParent(this.transform, false);
        }
    }


}
