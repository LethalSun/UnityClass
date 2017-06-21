using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Object: " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(0.0f, 100.0f, 0.0f);

        }
        else if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }


}
