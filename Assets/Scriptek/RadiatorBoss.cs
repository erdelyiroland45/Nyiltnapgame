using UnityEngine;

public class RadiatorBoss : MonoBehaviour
{
    public GameObject snowProjectilePrefab; // Prefab a h� l�ved�khez
    public Transform firePoint; // A pont, ahonnan a l�v�s indul
    public float fireRate = 1.5f; // L�v�s gyakoris�ga m�sodpercenk�nt
    public float projectileSpeed = 5f; // L�ved�k sebess�ge

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootSnow();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void ShootSnow()
    {
        // L�trehozzuk a h� l�ved�ket �s be�ll�tjuk a sebess�g�t
        GameObject snowProjectile = Instantiate(snowProjectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = snowProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * projectileSpeed;
    }
}
