using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerCount = 2;
    public int scorePlayer1;
    public int scorePlayer2;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Action<int> OnPlayer1Scored;
    public Action<int> OnPlayer2Scored;
    public Action OnPlayerScored;
    public Action<int> OnWinPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartGame(int players)
    {
        playerCount = players;
        SceneManager.LoadScene("Pong");
    }

    public void RestartGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        SceneManager.LoadScene("Menu");
    }

    public void Player1Scored()
    {
        scorePlayer1++;
        OnPlayer1Scored?.Invoke(scorePlayer1);
        if (!ScoreWin(scorePlayer1, 1))
            OnPlayerScored?.Invoke();
    }

    public void Player2Scored()
    {
        scorePlayer2++;
        OnPlayer2Scored?.Invoke(scorePlayer2);
        if (!ScoreWin(scorePlayer2, 2))
            OnPlayerScored?.Invoke();
    }
    private bool ScoreWin(int scorePlayer, int player)
    {
        if (scorePlayer >= 5)
        {
            OnWinPlayer?.Invoke(player);
            return true;
        }
        return false;
    }
}
