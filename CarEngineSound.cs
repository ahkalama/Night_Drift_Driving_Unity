using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource engineSound;
    public AudioSource aragazSound;
    public float maxPitch = 2.0f;
    public float minPitch = 1.0f;
    public float pitchChangeSpeed = 0.1f;
    private bool accelerating = false;

    public ParticleSystem particleSystem;
    public ParticleSystem particleSystem2;
    public  Light pointLight3;

    public FixedJoystick joystick;
    void Start()
    {
        engineSound.pitch = minPitch;
    }
    void Update()
    {
        float verticalInput = joystick.Vertical;

        if (verticalInput > 0)
        {
            accelerating = true;
        }
        else if (verticalInput < 0)
        {
            accelerating = false;
        }
        else
        {
            // Joystick 0'a yakınsa (bırakıldıysa)
            if (accelerating) // Eğer önceki durumda yukarıdaydıysa
            {
                accelerating = false; // Şimdi joystick bırakıldı
            }
        }
        // Accelerating durumuna göre motor sesini ayarla
        if (accelerating)
        {
            engineSound.pitch = Mathf.MoveTowards(engineSound.pitch, maxPitch, pitchChangeSpeed * Time.deltaTime);
        }
        else 
        {
            engineSound.pitch = Mathf.MoveTowards(engineSound.pitch, minPitch, pitchChangeSpeed * Time.deltaTime);
        }
    }
}
