using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownSayac : MonoBehaviour
{
    public int i;
    public Text CountDownDisplay;

    private void Start()
    {
        StartCoroutine(Sayac());
    }
    IEnumerator Sayac()
    {
        while(i > 0)
        {    
            CountDownDisplay.text = i.ToString();

            yield return new WaitForSeconds(2f);
            i--;
        }

        CountDownDisplay.text = "GO!";
        CountDownDisplay.gameObject.SetActive(false);
    }

}
