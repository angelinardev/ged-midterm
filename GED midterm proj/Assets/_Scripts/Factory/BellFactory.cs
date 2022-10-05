using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BellFactory : MonoBehaviour
{
    public abstract string Color {get;}

    public abstract GameObject Create(GameObject prefab); 
}
/* public class BellWhite : BellFactory
{
    public override string Color => "white";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        return enemy;
    }
} */
