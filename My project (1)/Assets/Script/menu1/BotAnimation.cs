using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotAnimation : MonoBehaviour
{
    private Vector3 permanentPosition ; // the last position 
    private Vector3 temperatePosition; // the updated position
    public Image nav; // panel include all object
   
    public GameObject chatbot; // empty object
    public Image bot; 
    public Image bot1;
    public Image bot2;
    public Image bot3;
    public Image chat;
    public int start=0;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        permanentPosition = new Vector3(135.7f,210.7f,0); // set up 
        chatbot.transform.position = new Vector3 (135.7f,127.8f,0);
        temperatePosition = chatbot.transform.position;
        
    }

    public void onClick()
    {
        // if click Start to animation
        if (!nav.gameObject.active) 
        {
            nav.gameObject.SetActive(true);

            StartCoroutine(startSlide(0.05f));
            
          
            StartCoroutine(actionStart2(0.8f));
            StartCoroutine(eyesBlinking());
           

        }
        else
        {
            start=0;
            chat.gameObject.SetActive(false);
            nav.gameObject.SetActive(true);
            StartCoroutine(startSlide(-0.05f));
        }
    }
   private void Update()
    {
        if (start == 1)
        {
             

            if (Time.time > startTime + 1.0f) { bot.gameObject.SetActive(false); }
            if (Time.time > startTime + 1.3f) { 
                bot.gameObject.SetActive(true);
                startTime = Time.time;
            }
            start = 1;
        }
    }
    IEnumerator eyesBlinking()
    {
    
        yield return new WaitForSeconds(1.0f);
        bot.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        bot.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        bot.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        bot.gameObject.SetActive(true);
        chat.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        start = 1;
        startTime = Time.time;


    }
    IEnumerator actionStart2(float i)
      {
        yield return new WaitForSeconds(0.01f);
        // transform all chatbot empty object as velocity i/0.01
        chatbot.transform.position = temperatePosition + new Vector3(0, i, 0);
       
        temperatePosition = chatbot.transform.position; // update new position
        if (chatbot.transform.position.y <= permanentPosition.y) 
        {
            StartCoroutine(actionStart2(i));
            
        }
        else { chatbot.transform.position = permanentPosition;
            
        }
    }
    IEnumerator startSlide(float i)
    {
        yield return new WaitForSeconds(0.01f);
        nav.fillAmount += i;
        bot.fillAmount += i;
        bot3.fillAmount += i;
        
        if ((nav.fillAmount < 1) && (nav.fillAmount > 0))
            StartCoroutine(startSlide(i));
        else if (nav.fillAmount == 0)
        {
            
            nav.gameObject.SetActive(false);
        }
    }
}
