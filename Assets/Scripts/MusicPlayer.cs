using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevel", 5f);

    }

    // Update is called once per frame
    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
