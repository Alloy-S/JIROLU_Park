using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerRightObstacle1 : MonoBehaviour
{
    public float speedPress;
    public float speedRelease;
    public Transform pos1;
    public Transform pos2;
    public GameObject btnTimer;
    bool isPressed = false;
    private float timer = 0f;
    public List<GameObject> platfroms;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /*Debug.Log(gameObject.tag + timer);*/
        // debug
        // foreach (GameObject platform in platfroms)
        // {
        //     platform.GetComponent<Platform>().showPlatform();
        // }

        if (ButtonTimer.timerB > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, speedPress * Time.deltaTime);
            /*btnTimer.GetComponent<ButtonTimer>().timerA -= Time.deltaTime;*/
            ButtonTimer.timerB -= Time.deltaTime;
            foreach (GameObject platform in platfroms)
            {
                platform.GetComponent<Platform>().showPlatform();
            }
        }
        else
        {

            /* Debug.Log("running hide");*/

            transform.position = Vector2.MoveTowards(transform.position, pos1.position, speedRelease * Time.deltaTime);
            foreach (GameObject platform in platfroms)
            {
                platform.GetComponent<Platform>().hidePlatform();
            }


        }

        if (ButtonTimer.timerB < 0)
        {
            ButtonTimer.timerB = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Debug.Log("button press");*/
        isPressed = true;
        ButtonTimer.timerB = +0.5f;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        /*Debug.Log("button press");*/
        isPressed = true;
        ButtonTimer.timerB = +0.5f;

    }

}
