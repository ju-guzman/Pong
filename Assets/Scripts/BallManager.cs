using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    const float INCREMENTO_VELOCIDAD = 1.4f;
    const float VELOCIDAD_MAXIMA = 15f;

    [SerializeField] private float Velocidad;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void PlayerScored()
    {
        transform.position = Vector3.zero;
        LanzarBola();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPlayerScored += PlayerScored;
        LanzarBola();
    }

    void LanzarBola()
    {
        var x = Random.Range(0, 2) * 2 - 1;
        var y = Random.Range(0, 2) * 2 - 1;
        rb.velocity = new Vector2(Velocidad * x, Velocidad * y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && rb.velocity.magnitude < VELOCIDAD_MAXIMA)
        {
            rb.velocity *= INCREMENTO_VELOCIDAD;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GolIzquierda"))
            GameManager.Instance.Player2Scored();
        else if (collision.gameObject.CompareTag("GolDerecha"))
            GameManager.Instance.Player1Scored();
    }
}
