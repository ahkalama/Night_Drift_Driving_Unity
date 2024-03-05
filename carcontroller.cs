using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System.Threading;

public class Carcontroller : MonoBehaviour
{
    // public REKLAMADDMOBS reklam; // reklam için eklemiştim artık ihtiyac kalmadı
    [SerializeField] private Text SpeedText;
    public FixedJoystick joystick;
    private Rigidbody m_Rigidbody;
    public WheelCollider solTeker, sagTeker, solarkaTeker, sagarkaTeker;
    public float motorGucu = 5000f;
    public float donusGucu = 150f;
    public ParticleSystem ALEV;
    public AudioSource hizsinirisound;
    private bool hasPlayed = false;

    [SerializeField] private float speed = 0f;

    private void Start()
    {
        ALEV.Stop();
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        speed = m_Rigidbody.velocity.magnitude * 2.23693629f;
        SpeedText.text = (m_Rigidbody.velocity.magnitude * 2.23693629f).ToString("0") + (" km/h");
    } 
    private void FixedUpdate()
    {
        float motorInput = joystick.Vertical;
        float donusInput = joystick.Horizontal;
        
        if(motorInput > 0)
        {
            if (speed < 200f)
            {
                solTeker.motorTorque = motorInput * motorGucu;
                sagTeker.motorTorque = motorInput * motorGucu;
                solarkaTeker.motorTorque = motorInput * motorGucu;
                sagarkaTeker.motorTorque = motorInput * motorGucu;
            }
            else if (speed > 200f)
            {
                solTeker.motorTorque = 300f;
                sagTeker.motorTorque = 300f;
                solarkaTeker.motorTorque = 300f;
                sagarkaTeker.motorTorque = 300f;
            }
        }
        else
        {
            solTeker.motorTorque = 0f;
            sagTeker.motorTorque = 0f;
            solarkaTeker.motorTorque = 0f;
            sagarkaTeker.motorTorque = 0f;
        }

        solTeker.steerAngle = donusInput * donusGucu;
        sagTeker.steerAngle = donusInput * donusGucu;

        float tekerlekDonus = donusInput * donusGucu;
        solTeker.transform.localEulerAngles = new Vector3(0, tekerlekDonus, 0);
        sagTeker.transform.localEulerAngles = new Vector3(0, tekerlekDonus, 0);

        if(speed > 120f && !hasPlayed)
        {
            hizsinirisound.Play();
            hasPlayed = true;
            ALEV.Play();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lav")
        {
            // reklam.ShowInterstitialAd();
            SceneManager.LoadScene(2);
        }
    }
}
