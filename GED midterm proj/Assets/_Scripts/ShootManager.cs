using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    
    public static ShootManager instance;
    public float shootSpeed = 1f;

    //one instance
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void ChangeSpeed(float s)
    {
        shootSpeed = s;
        //update shoot speed for the player as well
        PlayerController.instance.shootSpeed = shootSpeed;
       
    }

}
