using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turretHead;
    [SerializeField] private Transform playerTargetPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpawnRate = 3f;
    [SerializeField] private int damageAmount = 2;
    [SerializeField] private AudioClip shootClip;

    private AudioSource audioSource;
    private PlayerHealth player;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(ProjectileSpawnRoutine());
    }

    private void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    private IEnumerator ProjectileSpawnRoutine()
    {
        while (player != null)
        {
            yield return new WaitForSeconds(projectileSpawnRate);
            if (player != null)
            {
                Projectile p = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
                audioSource?.PlayOneShot(shootClip);
                p.transform.LookAt(player.transform);
                p.Setup(damageAmount);
            }
        }
    }
}
