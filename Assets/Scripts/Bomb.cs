using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject effectGround;
    public GameObject effectAir;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            MakeEffect(effectGround);
        }
        else
        {
            MakeEffect(effectAir);
        }

        Destroy(gameObject);
    }

    void MakeEffect(GameObject effect)
    {
        GameObject eff = Instantiate(effect) as GameObject;
        eff.transform.position = transform.position;
    }
}
