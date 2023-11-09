using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeReference] private GameObject winPanel;
    [SerializeReference] private TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnWinPlayer += ShowWinPanel;
    }

    private void ShowWinPanel(int playerNumber)
    {
        winPanel.SetActive(true);
        winText.text = $"{NumberToPlayerName(playerNumber)} PLAYER";
    }

    private object NumberToPlayerName(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                return "RED";
            case 2:
                return "BLUE";
            default:
                return "One";
        }
    }

    public void RestartLevelEvent()
    {
        GameManager.Instance.RestartGame();
    }
}
