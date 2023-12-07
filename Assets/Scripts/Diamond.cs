using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(30 * Time.deltaTime, 15 * Time.deltaTime, 45 * Time.deltaTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

