using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth = 5;

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
