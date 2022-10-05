using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //player reaches the flag
        if (collision.collider.tag == "Player")
        {
            //end game
            Debug.Log("You beat the game!");
            Application.Quit();
            
        }
    }
}
