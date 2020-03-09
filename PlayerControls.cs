using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10;
    float screenHalfWidthInWorldUnits;

    //event managment (1)
    public event System.Action OnPlayerDestroy;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;                                               // to create collision system
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth; // 1. change last + to a -
    }

    // Update is called once per frame
    void Update() 
    {
       
        float inputX = Input.GetAxis("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y); // 2. make screen width -
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(- screenHalfWidthInWorldUnits, transform.position.y); // 3. make screen width +
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "FallingBlock")
        {
            //event managment (2)
            if(OnPlayerDestroy != null)
            {
                OnPlayerDestroy();
            }
            Destroy(gameObject);
        }
    }
}
