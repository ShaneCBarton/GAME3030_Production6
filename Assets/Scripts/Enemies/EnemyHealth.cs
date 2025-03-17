using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private GameObject explosionVFXPrefab;
    
    private int currentHealth;
    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = startHealth;
    }
    
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustRemainingEnemies(1);
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameManager.AdjustRemainingEnemies(-1);
            SelfDesrtuct();
        }
    }

    public void SelfDesrtuct()
    {
        Instantiate(explosionVFXPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
