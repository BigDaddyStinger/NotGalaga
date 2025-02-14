using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float verticalInput = 1.0f;
    [SerializeField] float bottomY = -5.0f;
    [SerializeField] public int points = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        enemyMovement();
    }

    // Update is called once per frame
    public void Update()
    {

        enemyMovement();

        if (transform.position.y <= bottomY)
        {
            GameManager.Instance.ReduceLives(1);
            Destroy(gameObject);


        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Missile>() != null)
        {
            
            GameManager.Instance.AddScoreBig(20);
            Debug.Log("Enemy hit by " + collision.gameObject.name);
            
            Destroy(gameObject);

        }
        if (collision.GetComponent<Player>() != null)
        {
            GameManager.Instance.ReduceLives(1);
            Destroy(gameObject);
        }
    }

    public void enemyMovement()
    {
        if (GameManager.Instance.isGameOver == false)
        {
            verticalInput = Random.Range(2, 4);
            transform.Translate(verticalInput * Vector2.down * Time.deltaTime * speed);
        }
        else
            verticalInput = 0;
    }
}
