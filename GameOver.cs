using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //needed for text object
using UnityEngine.SceneManagement; //needed for starting scene
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

    private void Start()
    {
        //event managment (3)
        FindObjectOfType<PlayerControls>().OnPlayerDestroy += OnGameOver; //adding game over method to call queue when destory even occcures
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0); //can load by manager or name, must also add sceenes to build settings
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
