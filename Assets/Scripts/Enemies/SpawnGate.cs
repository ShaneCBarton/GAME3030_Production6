using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private AudioClip spawnClip;

    private PlayerHealth player;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            audioSource?.PlayOneShot(spawnClip);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
