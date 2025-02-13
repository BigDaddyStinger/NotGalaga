using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float verticalInput = 1.0f;
    [SerializeField] float position = 0.0f;
    [SerializeField] float rotation = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Random.Range(1,4);
        transform.Translate(verticalInput * Vector2.down * Time.deltaTime * speed);
    }
}
