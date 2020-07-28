using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;

    void Start()
    {
    }

    void OnParticleCollision(GameObject other)
    {
        print("got hit");
        Instantiate(deathFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
