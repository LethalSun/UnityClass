using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public Transform cameraTransform;
    public GameObject fireObject;
    public Transform firePosition;
    public float forwardPower = 20.0f;
    public float upPower = 5.0f;

	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireObject) as GameObject;


            obj.transform.position = firePosition.position;
            obj.GetComponent<Rigidbody>().velocity = (cameraTransform.forward * forwardPower) + (Vector3.up * upPower); 
        }
	}
}
