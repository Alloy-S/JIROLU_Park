using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.tag);
        GameHandler.getInstance().addPassedPlayer(collision.gameObject.tag);
        GameHandler.getInstance().addScorepoint(150f);
        Destroy(collision.gameObject);

    }
}
