using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyShipPrefab;
    [SerializeField] float difficultySlider = 1.0f;
    [SerializeField] float timeBetweenSpawn = 1.0f;
    [SerializeField] float elapsedSinceLastSpawn = 0.0f;
    [SerializeField] float difficultyTimer = 1.0f;
    [SerializeField] float difficultyIncreaseClock = 1.0f;
    [SerializeField] float speed = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IncreaseDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseDifficulty();

        elapsedSinceLastSpawn += Time.deltaTime;// ;

        if(elapsedSinceLastSpawn > timeBetweenSpawn * difficultySlider) 
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

    void IncreaseDifficulty()
    {
        difficultyTimer += Time.deltaTime * speed;
        //difficultyIncreaseClock = Time.deltaTime * speed;

        if(difficultyTimer > difficultyIncreaseClock && elapsedSinceLastSpawn > 0.3) 
        {
            difficultySlider -= 0.005f;
            difficultyTimer = 0.0f;
        }
    }
}
