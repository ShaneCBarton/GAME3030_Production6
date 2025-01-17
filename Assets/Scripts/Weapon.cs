using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private Animator animator;

    private StarterAssetsInputs starterAssetInputs;

    const string SHOOT_STRING = "Shoot";

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
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetInputs.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);
        }

    }
}


