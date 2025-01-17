using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    
    private int currentHealth;

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
