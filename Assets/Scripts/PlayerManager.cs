using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField] private float velocidad;
    [SerializeField] private string vectorDireccion;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager.playerCount < playerNumber)
        {
            GetComponent<NPCManager>().enabled = true;
            enabled = false;
        }
        gameManager.OnPlayerScored += PlayerScored;
    }

    private void PlayerScored()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }

    private void Update()
    {
        Mover(GetDireccion());
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

    float GetDireccion()
    {
        return Input.GetAxisRaw(vectorDireccion);
    }
}
