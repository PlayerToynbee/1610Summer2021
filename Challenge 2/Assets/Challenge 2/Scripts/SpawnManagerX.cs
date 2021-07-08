using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnInterval = 4.0f;

    private readonly float spawnLimitXLeft = -22;
    private readonly float spawnLimitXRight = 7;
    private readonly float spawnPosY = 30;

    private readonly float startDelay = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall()
    {
        spawnInterval = Random.Range(3, 5);
        // Generate random ball index and random spawn position
        var spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[0].transform.rotation);
        Invoke("SpawnRandomBall", spawnInterval);
    }
}