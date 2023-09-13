using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public static GameHandler instance;
    private int passedPlayer = 0;
    public GameObject timeupwindow;
    public GameObject howToPlayWindow;
    public GameObject timeUpWindow;
    public GameObject pauseWindow;
    public TextMeshProUGUI scoreTime;
    public TextMeshProUGUI titleScore;
    public TextMeshProUGUI ScoreText;

    private bool isButtonPressed;

    private bool player1 = false;
    private bool player2 = false;
    private bool player3 = false;

    private float scorePoint = 0;

    private bool win = false;
    private bool lose = false;

    private void Awake()
    {
        instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(GameManager.GetInstance().getGameState());
        // GameManager.GetInstance().updateGameState(GameState.waitingToStart);
        // Debug.Log(passedPlayer);
        Debug.Log(TimerSetting.waktu);

       

        if (Input.GetKey(KeyCode.Space) && GameManager.GetInstance().getGameState() == GameState.waitingToStart)
        {
            GameManager.GetInstance().updateGameState(GameState.playing);
            howToPlayWindow.SetActive(false);
            TimerSetting.waktu = 600;

        }

        if (TimerSetting.waktu <= 0 && !lose)
        {
            lose = true;
            GameManager.GetInstance().updateGameState(GameState.gameOver);
            scorePoint += TimerSetting.waktu;
            timeUpWindow.SetActive(true);
            addHighScore();
            
            TimerSetting.waktu = 1;
        }

        if (player1 && player2 && player3 && !win)
        {
            win = true;
            GameManager.GetInstance().updateGameState(GameState.win);
            setText(TimerSetting.waktu);
            titleScore.text = "You Win!";
            scorePoint += TimerSetting.waktu;
            ScoreText.text = scorePoint.ToString();
            timeupwindow.SetActive(true);
            addHighScore();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.GetInstance().getGameState() == GameState.playing && !isButtonPressed)
        {
            Debug.Log("paused");
            GameManager.GetInstance().updateGameState(GameState.pause);
            isButtonPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.GetInstance().getGameState() == GameState.pause && !isButtonPressed)
        {
            GameManager.GetInstance().updateGameState(GameState.playing);
            isButtonPressed = true;
        }

        if (GameManager.GetInstance().getGameState() == GameState.pause)
        {
            pauseWindow.SetActive(true);
        }
        else if (GameManager.GetInstance().getGameState() == GameState.playing)
        {
            pauseWindow.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isButtonPressed = false;
        }

        
    }

    [System.Obsolete]
    IEnumerator addHighscoreDB(string teamName, float time, float score) {
        // teamName = "budi";
        //time = 1000f;
        //score = 1100f;
        WWWForm form = new WWWForm();
        form.AddField("team_name", teamName);
        form.AddField("time", time.ToString());
        form.AddField("score", score.ToString());
        string url = "http://54.254.221.187:5000/api/highscore";
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
                Debug.Log("succes");
                Debug.Log(w.text);

            }
        }

        w.Dispose();
    }

    [System.Obsolete]
    public void addHighScore()
    {
        string name = PlayerPrefs.GetString("squadName");
        
        HighscoreEntry highscoreEntry = new HighscoreEntry { scoreTime = TimerSetting.waktu, name = name, scorePoint = scorePoint };

        // string jsonString = PlayerPrefs.GetString("highScoreTable");
        string jsonString = FileHandler.ReadFromJSON("highscore.json");
        HighScores highScore = JsonUtility.FromJson<HighScores>(jsonString);
        
        // WWWForm form = new WWWForm();
        // form.addField("name", name);
        // form.addField("point", scorePoint);
        // string url = "localhost/irgl/irgl.php";
        // WWW w = new WWW(url, form);
        StartCoroutine(addHighscoreDB(name, TimerSetting.waktu, scorePoint));

        highScore.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highScore);
        FileHandler.SaveToJSON<string>(json, "highscore.json");
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    public float getScorePoint()
    {
        return scorePoint;
    }

    public void addScorepoint(float point)
    {
        scorePoint += point;
    }

    public static GameHandler getInstance()
    {
        return instance;
    }

    public void reloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void resume()
    {
        GameManager.GetInstance().updateGameState(GameState.playing);
    }

    public void addPassedPlayer(string tag)
    {
        passedPlayer++;

        if (tag == "player1")
        {
            player1 = true;
        }
        else if (tag == "player2")
        {
            player2 = true;
        }
        else if (tag == "player3")
        {
            player3 = true;
        }
    }

    public void setText(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);

        scoreTime.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    private class HighScores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float scoreTime;
        public string name;

        public float scorePoint;
    }
}
