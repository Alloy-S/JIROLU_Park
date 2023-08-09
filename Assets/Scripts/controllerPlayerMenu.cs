using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerPlayerMenu : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform pos1Player1;
    public Transform pos2Player1;

    public Transform pos1Player2;
    public Transform pos2Player2;

    public Transform pos1Player3;
    public Transform pos2Player3;


    public float speed = 4f;

    public bool turnback;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.position.x >= pos1Player1.position.x)
        {
            turnback = true;

        }

        if (player1.position.x <= pos2Player1.position.x)
        {
            turnback = false;
        }


        if (turnback)
        {
            player1.position = Vector2.MoveTowards(player1.position, pos2Player1.position, speed * Time.deltaTime);
            player2.position = Vector2.MoveTowards(player2.position, pos2Player2.position, speed * Time.deltaTime);
            player3.position = Vector2.MoveTowards(player3.position, pos2Player3.position, speed * Time.deltaTime);
        }
        else
        {
            player1.position = Vector2.MoveTowards(player1.position, pos1Player1.position, speed * Time.deltaTime);
            player2.position = Vector2.MoveTowards(player2.position, pos1Player2.position, speed * Time.deltaTime);
            player3.position = Vector2.MoveTowards(player3.position, pos1Player3.position, speed * Time.deltaTime);
        }
        
    }
}
