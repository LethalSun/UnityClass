using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public Transform cameraTransform;
    public GameObject fireObject;
    public float forwardPower = 20.0f;
    public float upPower = 5.0f;

	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireObject) as GameObject;
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
          

            Vector3 crossProduct = Vector3.Cross(cameraTransform.forward, cameraTransform.up);

            float xc = crossProduct.x;
            float yc = crossProduct.y;
            float zc = crossProduct.z;
            Debug.Log("x = " + x + ", y = " + y + ", z = " + z);
            Debug.Log("xc = " + xc + ", yc = " + yc + ", zc = " + zc);
            obj.transform.position = transform.position + crossProduct;
            obj.GetComponent<Rigidbody>().velocity = (cameraTransform.forward * forwardPower) + (Vector3.up * upPower); 
        }
	}
}
