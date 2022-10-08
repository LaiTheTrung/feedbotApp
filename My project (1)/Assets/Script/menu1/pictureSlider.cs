using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pictureSlider : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    // max y location: y is the distance between main and checkpoint. Because when checkpoint touch the bottom of the screen, the value y of checkpoint is 0
    // min y loaction: y postion of checkpoint
    // note: the reason why don't take an abitary number is the location will change depend on the size of Screen


    public GameObject checkpoint;
    float max ;
    float min ;
    float percentageThreshold = 0.2f;
    private Vector3 mainPosition;
    private Vector3 Newposition;

    private Vector3 Maxposition; // the max position of main
    private Vector3 Minposition; // the min position of main
    void Start()
    {
        // find max postion:
        max = transform.position.y-checkpoint.transform.position.y;
        
        Debug.Log("Max");
        Debug.Log(max);
        Debug.Log("Min");
        Debug.Log(min);

        mainPosition = transform.position; // setup mainPosition at start postion
        Debug.Log("Start Pos");
        Debug.Log(mainPosition.y);
        Debug.Log("Screen Height");
        Debug.Log(Screen.height);
        Debug.Log(" ");
        Minposition = mainPosition;
        min = Minposition.y;
        // set up maxposition 
        Maxposition = mainPosition;
        Maxposition.y = max;
    }

public void OnDrag(PointerEventData data)
    {
     
        float different = data.pressPosition.y - data.position.y;

     
        Newposition = mainPosition - new Vector3(0, different, 0);
        
        if ((Newposition.y > min) & (Newposition.y < max)) // only drag available when the Newpostion response 2 condition:
        {
            transform.position = Newposition;
        }
        else // disaple dragging when
        {
            float a = max-Newposition.y ;
            if (a > 0) // this is the case colide with the top of screen
            {
                transform.position = Minposition;
            }
            else // this case, user drag to the end of the slide
            {
                transform.position = Maxposition;
            }
            return;
        }


        //  transform.position = Newposition;
        Debug.Log("Y main");
        Debug.Log(Newposition.y);
        Debug.Log(" ");


    }
public void OnEndDrag(PointerEventData data) // khi th? nút ?n thì 
    {
       
        mainPosition = Newposition; // setup l?i mainPosition
    }
}
