using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //player collides with door
        if (collision.collider.tag == "Player")
        {
            //if the player has the key, remove the door
            if (PlayerController.instance.GetKey())
            {
                Debug.Log("You unlocked the door");
                PlayerController.instance.SetKey(false);
                Destroy(gameObject);
            }
        }
    }
}
