using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;       
    public Transform gunPoint;            
    public float shootCooldown = 0.2f;    

    private float nextShootTime = 0f;

    public Transform player;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    void Shoot()
    {
        if (playerMovement.isFacingRight)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);

        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation * Quaternion.Euler(0, 0, 180));

        }

        
    }
}
