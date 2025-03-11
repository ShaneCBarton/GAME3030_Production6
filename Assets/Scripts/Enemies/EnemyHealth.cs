using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private GameObject RobotExplosionVFX;
    
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
            SelfDesrtuct();
        }
    }

    public void SelfDesrtuct()
    {
            Instantiate(RobotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
