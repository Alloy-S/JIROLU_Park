using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SquadInput : MonoBehaviour
{
    public TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(input.text);
        // Debug.Log("1");
    }

    public void okBtn() {
        if(input.text != "") {
            PlayerPrefs.SetString("squadName", input.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
        } 
    }

    public void cancelBtn() {
        input.text = "";
        gameObject.SetActive(false);
    }

    public void startBtn() {
        gameObject.SetActive(true);
    }

    public void exitBtn() {
        Application.Quit();
    }
}
