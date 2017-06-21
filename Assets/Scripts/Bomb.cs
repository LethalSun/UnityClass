using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject effect;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("sdfawetasdfasdfasdfasdfasdf"+other.gameObject.name);
        GameObject eff = Instantiate(effect) as GameObject;
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
}
