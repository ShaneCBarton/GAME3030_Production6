using System.Collections;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] protected AudioClip ammoClip;
    [SerializeField] protected AudioClip weaponClip;

    private const string PLAYER_STRING = "Player";

    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);

}
