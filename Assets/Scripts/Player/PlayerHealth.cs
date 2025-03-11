using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private int startHealth = 5;
    [SerializeField] private CinemachineVirtualCamera deathCamera;
    [SerializeField] private Transform weaponCamera;
    [SerializeField] private Image[] shieldBars;

    private int currentHealth;
    private int deathCameraPriority = 20;

    private void Awake()
    {
        currentHealth = startHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathCamera.Priority = deathCameraPriority;
            Destroy(gameObject);
        }
    }

    private void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            } 
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
