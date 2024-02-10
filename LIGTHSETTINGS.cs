using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    // Işık yoğunluğunun en düşük ve en yüksek değerleri.
    public float minIntensity = 0.5f;
    public float maxIntensity = 2.0f;

    // Işık yanıp sönme hızı.
    public float blinkSpeed = 1.0f;

    // Işık bileşeni ve hedef yoğunluk değeri.
    private Light lightComponent;
    private float targetIntensity;

    // Oyun nesnesi başlatıldığında çalışır.
    void Start()
    {
        // Işık bileşenini alır.
        lightComponent = GetComponent<Light>();
        
        // Hedef yoğunluğu rasgele bir değere ayarlar.
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    // Her güncelleme (frame) adımında çalışır.
    void Update()
    {
        // Işık yoğunluğunu belirli bir hızda hedef yoğunluğa doğru günceller.
        lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, targetIntensity, Time.deltaTime * blinkSpeed);

        // Eğer ışık yoğunluğu hedef yoğunluğa yakınsa...
        if (Mathf.Approximately(lightComponent.intensity, targetIntensity))
        {
            // Yeni bir rasgele hedef yoğunluk değeri seçer.
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
