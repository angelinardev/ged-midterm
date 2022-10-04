using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //player picks up the key
        if (collision.collider.tag == "Player")
        {
           PlayerController.instance.SetKey(true);
            Debug.Log("You got the key");
            Destroy(gameObject);
        }
    }
}
