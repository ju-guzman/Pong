using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame(int players)
    {
        GameManager.Instance.StartGame(players);
    }
}
