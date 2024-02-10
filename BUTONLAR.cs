using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BUTONLAR : MonoBehaviour
{
    public Light flashlight;
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystem2;
    public AudioSource aragazSound;
    public AudioSource musicbutton;
    private bool flagVisible = false;
    private bool musicflag = true;
    public GameObject flag;
    public Light pointLight;
    public  Light pointLight2;
    public Light pointLight3;
    public  Light pointLight4;

    public WheelCollider solarkaTeker, sagarkaTeker;

    public void PlayButton() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void MusicButton()
    {

        if (musicflag == true)
        {
            musicbutton.Pause();
            musicflag = false;
        }
        else
        {
            musicbutton.Play();
            musicflag = true;
        }
    }
    public void Lightbutton()
    {
        flashlight.enabled = !flashlight.enabled;
        pointLight3.enabled = !pointLight3.enabled;
        pointLight4.enabled = !pointLight4.enabled;
    }

    public void Gaspedalbutton()
    {
        aragazSound.Play();
        particleSystem.Play();
        particleSystem2.Play();
    }

    public void Brakepedalbutton()
    {
        pointLight.enabled = !pointLight.enabled;
        pointLight2.enabled = !pointLight2.enabled;
        solarkaTeker.brakeTorque = 50000;
        sagarkaTeker.brakeTorque = 50000;

        StartCoroutine(ReleaseBrake());
    }
    public void ToggleFlagVisibility()
    {
        if (flag != null) // flag oyun nesnesi varsa
        {
            flag.SetActive(flagVisible); // flag'ın görünürlüğünü flagVisible değişkenine göre ayarla
            flagVisible = !flagVisible; // flagVisible'ı tersine çevir (true ise false, false ise true yap)
        }
    }
    
    private IEnumerator ReleaseBrake()
    {
        // Belirli bir süre sonra freni serbest bırak
        yield return new WaitForSeconds(1f); // Freni 1 saniye sonra serbest bırakabilirsiniz (Bu süreyi ihtiyacınıza göre ayarlayın)
        
        // Freni serbest bırak
        solarkaTeker.brakeTorque = 0;
        sagarkaTeker.brakeTorque = 0;
    }
}
