using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTouch : MonoBehaviour
{
    [SerializeField] private Transform chechPoint;
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3")
        {
            transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "Spike" ) {
            die();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Debug.Log("stay");
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3")
        {
            transform.parent = null;
        }
    }

    void die() {
        StartCoroutine(respawn(1f));
    }

    IEnumerator respawn(float duration) {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = chechPoint.position;
        spriteRenderer.enabled = true;
    }
}
