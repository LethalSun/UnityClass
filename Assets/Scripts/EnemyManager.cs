using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 2.0f;

    float deltaTime = 0.0f;

    void Update ()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime > spawnTime)
        {
            deltaTime = 0.0f;

            GameObject enemyObj = Instantiate(enemy) as GameObject;

            Transform playerTr = CharacterMove.instance.transform;


            Vector3 spawnPos = playerTr.forward * Random.Range(5.0f, 10.0f);

            spawnPos += playerTr.right * Random.Range(-5, 6);

            //spawnPos.x += Random.Range(-10.0f, 10.0f);
            //spawnPos.z += Random.Range()

            enemyObj.transform.position = spawnPos;
        }
	}
}
