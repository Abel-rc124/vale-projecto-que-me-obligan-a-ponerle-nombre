using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spaw : MonoBehaviour
{
    float spawnTimer;
    public Transform borderLeft;
    public Transform borderRight;
    public  GameObject prefab;
    float spawnInterval = 0.2f;
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {

            Spawn();
        }



    }



     void Spawn()
{
        float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);

        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        Instantiate(prefab, newPosition, Quaternion.identity);
        spawnTimer = spawnInterval;




}



}