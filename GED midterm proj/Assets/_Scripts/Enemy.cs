using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //enemy was hit by bullet
        if (collision.collider.tag == "Bullet")
        {
            //kills enemy
            Destroy(gameObject);
        }
    }
}
