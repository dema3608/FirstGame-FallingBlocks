using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// see https://www.youtube.com/watch?v=beWwwxn7dLQ&list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw&index=16
public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public Vector2 spawnDelayMinMax;
    float nextSpawnTime;
    public float spawnAngleMax;

    public Vector2 spawnSizeMinMax;
    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            // with a,b, p to move between a and b use value = a + (b-a)p  p=0 ==> a and p=1 ==> b [linear interpelation] LERP

            float secondsBetweenSpawns = Mathf.Lerp(spawnDelayMinMax.y, spawnDelayMinMax.x, Difficulty.getDifficultyPercent());
            //print(secondsBetweenSpawns);
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newSphere = (GameObject) Instantiate(spherePrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle) );
            newSphere.transform.localScale = Vector2.one * spawnSize; // a scale of spawn size on both x and y axis  
        }
    }
}
