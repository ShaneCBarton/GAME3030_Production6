using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth = 5;
    [SerializeField] private CinemachineVirtualCamera deathCamera;
    [SerializeField] private Transform weaponCamera;

    private int currentHealth;
    private int deathCameraPriority = 20;

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathCamera.Priority = deathCameraPriority;
            Destroy(gameObject);
        }
    }
}
