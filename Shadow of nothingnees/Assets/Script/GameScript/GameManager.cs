using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
     Gameplay,
     Paused,
     GameOver
    
    }

    public GameState currentState;

    public GameState previousState;



    [Header("UI")]
    public GameObject pauseScrean;

    void Awake()
    {
        DisableScreaen();
    }


    private void Update()
    {
       


        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                break;

            default:
                Debug.LogWarning("State does not exist");
                break;
        }

    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }


    public void PauseGame ()
    {
        if(currentState!=GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScrean.SetActive(true);
            Debug.Log("Game is paused");
        }


 
    }

    public void ResumeGame()
    {
        if(currentState==GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScrean.SetActive(false);
            Debug.Log("Game is resume");
        }
    }

    void CheckForPauseAndResume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState==GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreaen()
    {
        pauseScrean.SetActive(false);
    }
}
