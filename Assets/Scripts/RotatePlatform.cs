using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed;
    private float durationDelay;
    private bool available;
    [SerializeField] private float duration;
    // Start is called before the first frame update
    void Start()
    {
        durationDelay = Time.time;
    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.GetInstance().getGameState() == GameState.playing)
        {
            // Debug.Log(Time.time);
            // Debug.Log("z: " + transform.rotation.z);
                //    if (transform.rotation.z == 0.99f)
                //     {
                //         Debug.Log("stop");
                //     }
            // transform.Rotate(0f, 0f, speed);
            rotate();
        }
    }

    void rotate() {
        if ((transform.rotation.z >= 1f || transform.rotation.z <= -1f) && available) {
            durationDelay = Time.time + duration;
            available = false;
        } 
        
        if (Time.time > durationDelay) {
            available = true;
            transform.Rotate(0f, 0f, speed);
        }

    }
}
