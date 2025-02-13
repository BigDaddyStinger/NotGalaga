using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyShipPrefab;
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

        if(elapsedSinceLastSpawn > timeBetweenSpawn) 
        {
            SpawnShips();
            elapsedSinceLastSpawn = 0.0f;
        }

    }

    void SpawnShips()
    {
        int rx = Random.Range(-8, 8);
        Vector3 position = new Vector3(rx, 6, 0);
        Instantiate(enemyShipPrefab, position, Quaternion.identity);
    }
}
