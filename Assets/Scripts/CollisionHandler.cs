using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] float levelLoadDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider collision)
    {
        StartDeath();
    }

    private void StartDeath()
    {
        SendMessage("OnPlayerDeath");
        deathFx.SetActive(true);
        Invoke("LoadLevel", levelLoadDelay);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
