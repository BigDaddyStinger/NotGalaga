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
        verticalInput = Random.Range(3, 8);
    }

    // Update is called once per frame
    public void Update()
    {

        transform.Translate(verticalInput * Vector2.down * Time.deltaTime * speed);

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
    }
}
