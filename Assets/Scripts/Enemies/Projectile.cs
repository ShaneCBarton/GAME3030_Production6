using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private GameObject projectileVFX;

    private Rigidbody rb;
    private int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Setup(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        player?.TakeDamage(damage);

        Instantiate(projectileVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
