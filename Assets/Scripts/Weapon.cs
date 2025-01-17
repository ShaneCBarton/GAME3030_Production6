using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private ParticleSystem muzzleFlash;

    private StarterAssetsInputs starterAssetInputs;

    private void Awake()
    {
        starterAssetInputs = GetComponentInParent<StarterAssetsInputs>();
    }



    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!starterAssetInputs.shoot) return;

        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);
        }

        starterAssetInputs.ShootInput(false);
    }
}


