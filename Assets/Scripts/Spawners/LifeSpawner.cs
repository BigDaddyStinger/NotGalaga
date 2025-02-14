using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField] GameObject LifePrefab;
    [SerializeField] float difficultySlider = 1.0f;
    [SerializeField] float timeBetweenSpawn = 1.0f;
    [SerializeField] float elapsedSinceLastSpawn = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedSinceLastSpawn += Time.deltaTime * difficultySlider;

        if (elapsedSinceLastSpawn > timeBetweenSpawn)
        {
            SpawnShips();
            elapsedSinceLastSpawn = 0.0f;
        }

    }

    void SpawnShips()
    {
        int rx = Random.Range(-8, 8);
        Vector3 position = new Vector3(rx, 6, 0);
        Instantiate(LifePrefab, position, Quaternion.identity);
    }
}
