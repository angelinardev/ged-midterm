using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBell : BellFactory
{
     public override string Color => "white";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        return enemy;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            ShootManager.instance.ChangeSpeed(0.3f); //lower number = faster
            Destroy(gameObject);
        }
    }
}
