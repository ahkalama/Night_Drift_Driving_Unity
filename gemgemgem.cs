using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//score point ekleme
public class gemgemgem : MonoBehaviour
{
    public AudioSource audiocoin;
    private void OnTriggerEnter(Collider other)
    {
        audiocoin.Play();
        COLLECT.score += 100;
        Destroy(gameObject);
    }
}
