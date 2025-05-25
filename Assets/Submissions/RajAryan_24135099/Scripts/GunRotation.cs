using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public SpriteRenderer gunSpriteRenderer;
    public Transform player;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mouseWorld - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    
        if (angle > 90 || angle < -90)
        {
            
            if (playerMovement.isFacingRight)
            {
                playerMovement.isFacingRight = false;
                Vector3 localScale = player.localScale;
                localScale.x = -Mathf.Abs(localScale.x); 
                player.localScale = localScale;
            }

            transform.rotation = Quaternion.Euler(0, 0, angle + 180);
        }
        else
        {
           
            if (!playerMovement.isFacingRight)
            {
                playerMovement.isFacingRight = true;
                Vector3 localScale = player.localScale;
                localScale.x = Mathf.Abs(localScale.x); 
                player.localScale = localScale;
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
