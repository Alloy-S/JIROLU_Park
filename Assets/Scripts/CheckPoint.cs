using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject door;
    private bool player1CheckPoint = false;
    private bool player2CheckPoint = false;
    private bool player3CheckPoint = false;

    void Update()
    {
        // Debug.Log("run");
        if (player1CheckPoint && player2CheckPoint && player3CheckPoint)
        {
            door.GetComponent<MovingPlatformManual>().hidePlatform();
        } else {
            door.GetComponent<MovingPlatformManual>().showPlatform();
        }

        

        // Debug.Log(player1CheckPoint + " " + player2CheckPoint + " " + player3CheckPoint);
    }


    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "player1")
    //     {
    //         if (player1CheckPoint == false)
    //         {
    //             GameHandler.getInstance().addScorepoint(150f);
    //         }
    //         player1CheckPoint = true;

    //     }
    //     else if (collision.gameObject.tag == "player2")
    //     {
    //         if (player2CheckPoint == false)
    //         {
    //             GameHandler.getInstance().addScorepoint(150f);
    //         }
    //         player2CheckPoint = true;
    //     }
    //     else if (collision.gameObject.tag == "player3")
    //     {
    //         if (player3CheckPoint == false)
    //         {
    //             GameHandler.getInstance().addScorepoint(150f);
    //         }
    //         player3CheckPoint = true;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Code to execute when another object exits the trigger
        Debug.Log("Enter trigger: " + collision.tag);
        if (collision.gameObject.tag == "player1")
        {
            if (player1CheckPoint == false)
            {
                GameHandler.getInstance().addScorepoint(150f);
            }
            player1CheckPoint = true;
        }
        else if (collision.gameObject.tag == "player2")
        {
            if (player2CheckPoint == false)
            {
                GameHandler.getInstance().addScorepoint(150f);
            }
            player2CheckPoint = true;
        }
        else if (collision.gameObject.tag == "player3")
        {
            if (player3CheckPoint == false)
            {
                GameHandler.getInstance().addScorepoint(150f);
            }
            player3CheckPoint = true;
        }
    }
}
