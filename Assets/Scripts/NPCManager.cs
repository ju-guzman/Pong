using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject Ball;
    [SerializeField] private float velocidad;

    private void Start()
    {
        GameManager.Instance.OnPlayerScored += PlayerScored;
    }

    private void PlayerScored()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }

    private void Update()
    {
        Mover(CalcularDireccionBola());
    }

    private float CalcularDireccionBola()
    {
        if (Ball.transform.position.y > transform.position.y)
        {
            return 1;
        }
        else if (Ball.transform.position.y < transform.position.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    void Mover(float direction)
    {
        if ((gameObject.transform.position.y >= 4 && direction > 0) || (gameObject.transform.position.y <= -4 && direction < 0))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            return;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, direction) * velocidad;
    }
}
