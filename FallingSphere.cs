using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSphere : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float visibleHeightThreshold;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime); //could add space.world
        if (transform.position.y < visibleHeightThreshold)
            Destroy(gameObject);     

    }
}
