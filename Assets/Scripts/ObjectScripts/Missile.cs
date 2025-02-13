using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float missileSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * missileSpeed);
        if(transform.position.y > 4.5)
        {
            Destroy(gameObject);
        }
    }
}
