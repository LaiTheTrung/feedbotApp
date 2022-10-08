using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Image nav;
    public Image Bone;
    public Image Btwo;
    
    // Start is called before the first frame update
  
    public void navStart()
    {
        if (!nav.gameObject.active)
        {
            nav.gameObject.SetActive(true);

            StartCoroutine(startSlide(0.05f));
        }
        else
        {
            nav.gameObject.SetActive(true);
            StartCoroutine(startSlide(-0.05f));
        }
    }
    IEnumerator startSlide(float i)
    {
        yield return new WaitForSeconds(0.01f);
        nav.fillAmount += i;
        Bone.fillAmount += i;
        Btwo.fillAmount += i;
        if ((nav.fillAmount < 1) && (nav.fillAmount > 0))
            StartCoroutine(startSlide(i));
        else if (nav.fillAmount == 0)
            {
            nav.gameObject.SetActive(false);
        } 
    }

}
