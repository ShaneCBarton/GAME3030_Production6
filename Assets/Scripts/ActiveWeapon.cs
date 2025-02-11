using StarterAssets;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;

    private Animator animator;
    private StarterAssetsInputs starterAssetInputs;
    private Weapon currentWeapon;
    private float timeSinceLastShot = 0f;

    const string SHOOT_STRING = "Shoot";


    private void Awake()
    {
        starterAssetInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!starterAssetInputs.shoot) return;

        if (timeSinceLastShot > weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetInputs.ShootInput(false);
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Player picked up: " + weaponSO.name);
    }
}
