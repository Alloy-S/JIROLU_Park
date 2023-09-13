using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SquadInput : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject failedWindow;
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

    public void okBtn()
    {
        if (input.text != "")
        {
            if (input.text == "-")
            {
                PlayerPrefs.SetString("squadName", input.text);
                PlayerPrefs.Save();
                SceneManager.LoadScene("MainScene");
            }

            Debug.Log(input.text);
            StartCoroutine(checkTeam());

        }
    }

    public void cancelBtn()
    {
        input.text = "";
        gameObject.SetActive(false);
    }

    public void startBtn()
    {
        gameObject.SetActive(true);
    }

    public void exitBtn()
    {
        Application.Quit();
    }

    IEnumerator checkTeam()
    {
        WWWForm form = new WWWForm();
        form.AddField("nama_tim", input.text);
        // form.AddField("point", 1000);
        // g4jaht3rbang
        string url = "https://irgl.petra.ac.id/main/api_cek_tim";
        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("submit gagal");
            Debug.Log(w.error);
        }
        else
        {
            if (w.isDone)
            {
                // Debug.Log(w.text);

                if (w.text == "berhasil")
                {
                    Debug.Log(input.text + " valid name!!");
                    PlayerPrefs.SetString("squadName", input.text);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("MainScene");



                }
                else
                {
                    Debug.Log("nama tidak ada");
                    failedWindow.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }

        w.Dispose();
    }
}
