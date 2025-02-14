using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float verticalInput = 1.0f;
    [SerializeField] float bottomY = -5.0f;
    [SerializeField] public int lives = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        healthUpMovement();
    }

    // Update is called once per frame
    public void Update()
    {
        healthUpMovement();
        

        if (transform.position.y <= bottomY)
        {

            Destroy(gameObject);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Missile>() != null)
        {
            GameManager.Instance.AddLives(1);
            Debug.Log("Enemy hit by " + collision.gameObject.name);

            Destroy(gameObject);

        }
        if (collision.GetComponent<Player>() != null)
        {
            GameManager.Instance.AddLives(1);
            Destroy(gameObject);
        }
    }

    public void healthUpMovement()
    {
        if (GameManager.Instance.isGameOver == false)
        {
            verticalInput = Random.Range(3, 8);
            transform.Translate(verticalInput * Vector2.down * Time.deltaTime * speed);
        }
        else
            verticalInput = 0;
    }
}
