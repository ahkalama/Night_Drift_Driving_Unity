using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadcontroller : MonoBehaviour
{
// Sonsuz Yol Oluşturucu
    public GameObject space;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "araba1")
        {
            transform.position += new Vector3(0, 0, transform.GetComponent<Renderer>().bounds.size.z * 4.3f);
            Destroy(space);
        }
    }
}
