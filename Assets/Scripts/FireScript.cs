using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public Transform cameraTransform;
    public GameObject fireObject;
    public Transform firePosition;
    public float forwardPower = 20.0f;
    public float upPower = 5.0f;
    public float maxRotate = 30.0f;
    public float minRotate = -30.0f;
	
	// Update is called once per frame
	void Update ()
    {
        if(GetComponent<PlayerState>().hp <= 0)
        {
            return;
        }

		if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireObject) as GameObject;


            obj.transform.position = firePosition.position;
            obj.GetComponent<Rigidbody>().velocity = (cameraTransform.forward * forwardPower) + (Vector3.up * upPower);
            float rot = Random.Range(minRotate, maxRotate);
            obj.transform.rotation = Quaternion.Euler(rot, rot, rot);      
        }
	}
}
