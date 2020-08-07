using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int value = 10;
    [SerializeField] int health = 50;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        print("got hit");
        scoreBoard.ScoreHit(value);
        shouldDie();
    }

    void shouldDie()
    {
        if (health < 10) { 
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        scoreBoard.ScoreHit(value * 5);
        Destroy(gameObject);
        } else
        {
            health -= 10;
        }
    }
}
