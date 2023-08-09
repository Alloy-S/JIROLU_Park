using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameState state;
    private static GameManager instance;

    public static GameManager GetInstance() {
        return instance;
    }

    
    private void Awake() {
        instance = this;
        // state = GameState.waitingToStart;
    }

    void Start() {
        state = GameState.waitingToStart;
    }

    public void updateGameState(GameState newState) {
        state = newState;
    }

    public GameState getGameState() {
        return state;
    }
    
}

public enum GameState {
        waitingToStart,
        playing,
        gameOver,
        win,
        pause
    }

