using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Transform cam;

    float damage = 10f;
    //[SerializeField] float range = 100f;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    //public ParticleSystem muzzleFlash;
    private void Awake()
    {
        cam = Camera.main.transform;
        
    }


    private void Start()
    {
        Debug.Log("on WeaponController");
        //Debug.Log(cam.name);
    }

    public void Shoot()
    {
        RaycastHit hit;

        // muzzleFlash.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            ProjectileHit target = hit.transform.GetComponent<ProjectileHit>();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

          //  Debug.Log(target.name);
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
            Destroy(bullet, 2f);
        }
    }
}
