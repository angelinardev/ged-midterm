using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using TMPro;

public class BellCreateFactory : MonoBehaviour
{
    public GameObject prefab1;//white bell


    List<BellFactory> bells;
    // Start is called before the first frame update
    void Start()
    {
        var bellTypes = Assembly.GetAssembly(typeof(BellFactory)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BellFactory)));

        bells = new List<BellFactory>();

        foreach(var type in bellTypes)
        {
            var tempType = Activator.CreateInstance(type) as BellFactory;
            bells.Add(tempType);
        }

    }

    public BellFactory GetEnemy(string bellType)
    {
        foreach(BellFactory bell in bells)
        {
            if(bell.Color == bellType)
            {
                Debug.Log("bell found");
                var target = Activator.CreateInstance(bell.GetType()) as BellFactory;

                return target;
            }
        }
        return null;
    }
    IEnumerator CreateBells()
    {
        yield return new WaitForSeconds(2f);
        AddBell();
    }
    void AddBell()
    {
        foreach(BellFactory bell in bells)
        {
            var newBell = bell.Create(prefab1);
            //this should be randomized position
            newBell.transform.position += new Vector3(1, 0, 0);
        }
    }

    void Update() {
    {
        StartCoroutine(CreateBells());
    }
   }
}
