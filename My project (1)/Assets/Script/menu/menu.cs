using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loading;
    public Slider slider_;
    public void PlayGame ()
    {
        mainMenu.SetActive(false);
        loading.SetActive(true);
        StartCoroutine(startSlider(0.01f));
    
    }
    IEnumerator startSlider(float i) // when button click, slider will change value till reach 1 and set the menu1 active
    {
        yield return new WaitForSeconds(0.01f);
        slider_.value = slider_.value + i;
        Debug.Log(slider_.value);
        if ((slider_.value < 1) && (slider_.value > 0))
            StartCoroutine(startSlider(i));
        else if (slider_.value >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // change scence
        }
    }
}
