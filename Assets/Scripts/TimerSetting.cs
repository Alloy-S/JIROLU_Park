using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerSetting : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public GameObject timeUpWindow;
    public static float waktu = 10;
    float s;

    public static TimerSetting instance;

    public static TimerSetting GetTimerSetting() {
        return instance;
    }

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().getGameState() == GameState.playing)
        {

            // if (waktu <= 0) {
            //     GameManager.GetInstance().updateGameState(GameState.gameOver);
            //     timeUpWindow.SetActive(true);
            // }

            setText();
            s += Time.deltaTime;
            if (s > 1)
            {
                waktu--;
                s = 0;
            }

            if(waktu < 0) {
                waktu = 0;
            }

            
        }
    }

    public void setText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);

        timerText.text = menit.ToString("00") + ":" + detik.ToString("00");
    }
}
