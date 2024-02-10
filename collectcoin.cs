using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class collectcoin : MonoBehaviour
{
    public AudioSource audio;
    public GameObject coin;
    void Start()
    {
        InvokeRepeating("Spawner", 15f, 5f);
    }

    void Spawner()
    {
        float range = Random.Range(35, 10);
        Instantiate(coin, new Vector3(range, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
