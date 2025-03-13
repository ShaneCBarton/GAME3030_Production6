using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnTransform;

    private PlayerHealth player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (player)
        {
            Instantiate(enemyPrefab, spawnTransform.position, transform.rotation);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
