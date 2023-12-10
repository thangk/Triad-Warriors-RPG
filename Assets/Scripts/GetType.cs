using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetType : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // print gameObject name and type to console
        print(gameObject.name + " is a " + gameObject.GetType());
    }
}
