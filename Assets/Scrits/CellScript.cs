using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    // 0 = nothing, 1 = wall
    int myStat = 0;

    public int MyRow;
    public int MyCollumn;

    public GameObject WhoOnMe;

    BoxCollider2D myCol;

    public Color Wall;
    public Color None;
    public enum Collors
    {
        wall = 1,
        none
    }

    private void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
        IsTriggerCheck(myStat);

    }

    public void SetCollor(Collors col)
    {
        switch (col)
        {
            case Collors.wall:
                {
                    GetComponent<Image>().color = Wall;
                    myStat = (int)col;
                    break;
                }

            case Collors.none:
                {
                    GetComponent<Image>().color = None;
                    myStat = (int)col;
                    IsTriggerCheck(myStat);

                    break;
                }
        }
    }

    public void IsTriggerCheck(int stat)
    {
        switch (stat)
        {
            case 1:
                {
                    myCol.isTrigger = false;

                    break;
                }

            case 2:
                {
                    myCol.isTrigger = true;

                    break;
                }
        }
    }

    public void ChangeMyObject(GameObject myObj)
    {
        if(myObj == null)
        {
            WhoOnMe = null;
        }
        else
        {
            WhoOnMe = myObj;
        }
    }
}
