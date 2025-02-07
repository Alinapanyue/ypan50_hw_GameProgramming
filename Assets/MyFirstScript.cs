using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        print("test start");
    }

    // Update is called once per frame
    void Update()
    {
        print("test");
    }

    // Destroyed at the end
    void OnDestroy()
    {
        print("Object is being destroyed!");
    }
}
