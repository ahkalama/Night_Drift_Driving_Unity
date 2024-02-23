using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CarTransform;
    void LateUpdate() {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, CarTransform.position.z - 14.8f);
    }
}

// LateUpdate fonksiyonu, diğer tüm Update fonksiyonları çağrıldıktan sonra çalıştırılır.
// Yani diğer nesnelerin pozisyonları vb. güncellendikten sonra kamera pozisyonunu ayarlar.
