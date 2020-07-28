using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
   
    int currentScene = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if( currentScene == 0)
        {
            Invoke("startGame", 5f);
        }

    }

    // Update is called once per frame
    void startGame()
    {
        SceneManager.LoadScene(1);
    }


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
