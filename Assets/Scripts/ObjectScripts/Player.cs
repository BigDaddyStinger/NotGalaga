using Mono.Cecil.Cil;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject missilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * Vector2.up * Time.deltaTime * speed);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * Vector2.right * Time.deltaTime * speed);

        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Hit Something");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {

        }
         
        Debug.Log("Player Touched " + collision.gameObject.name);
    }

}
