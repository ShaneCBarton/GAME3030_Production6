using Cinemachine;
using Mono.Cecil;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] private GameObject zoomVignette;

    private Animator animator;
    private StarterAssetsInputs starterAssetInputs;
    private FirstPersonController firstPersonController;
    private Weapon currentWeapon;
    private float timeSinceLastShot = 0f;
    private float defaultFOV;
    private float defaultRotationSpeed; 

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    private void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

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
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }

    private void HandleZoom()
    {
        if (!weaponSO.CanZoom) { return; }

        if (starterAssetInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
