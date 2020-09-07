using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 1;
    public GameObject BattlseScene;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        BattlseScene = GameObject.FindGameObjectWithTag("BattleScene");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            MoveHorizontal();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            MoveVertical();
        }                           
    }

    private void FixedUpdate()
    {

    }

    private void MoveHorizontal()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
    }

    private void MoveVertical()
    {
        rb.velocity = new Vector2(0, Input.GetAxis("Vertical") * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("hello" + collision.name);

        transform.position = collision.transform.position;
        rb.velocity = Vector2.zero;
        collision.GetComponent<CellScript>().ChangeMyObject(this.gameObject);

        if(collision.GetComponent<CellScript>().myStat == 3)
        {
            Debug.Log("enemy");
            GameController.TurnBattle();
            Camera.main.transform.position = new Vector3( BattlseScene.transform.position.x , BattlseScene.transform.position.y, Camera.main.transform.position.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       // rb.AddForce((collision.transform.position - transform.position) * Speed);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<CellScript>().ChangeMyObject(null);
    }
}
