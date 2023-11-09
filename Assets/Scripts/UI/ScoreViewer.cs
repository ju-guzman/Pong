using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private int numPlayer;
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        switch (numPlayer)
        {
            case 1:
                GameManager.Instance.OnPlayer1Scored += UpdateScore;
                break;
            case 2:
                GameManager.Instance.OnPlayer2Scored += UpdateScore;
                break;
            default:
                GameManager.Instance.OnPlayer1Scored += UpdateScore;
                break;
        }
    }

    private void UpdateScore(int score)
    {
        textMesh.text = score.ToString();
    }
}
