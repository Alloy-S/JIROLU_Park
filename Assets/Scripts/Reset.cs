using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R)) {
            HighScoreTable.getInstance().resetHighscore();
            // HighScoreTable.getInstance().addHighScoreEntry(100, "ASH", 1000);
            Debug.Log("reset");
        }
    }
}
