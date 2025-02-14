using Mono.Cecil.Cil;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float boundaryX = 8.0f;
    [SerializeField] float boundaryY = 4.75f;
    [SerializeField] Transform firePoint;
    [SerializeField] Vector3 offset;
    public int points;

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

        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -boundaryX, boundaryX);
        transform.position = clampedPosition;

        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -boundaryY, boundaryY);
        transform.position = clampedPosition;

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(missilePrefab, transform.position + offset, Quaternion.identity);
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
