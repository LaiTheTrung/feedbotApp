using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeB : MonoBehaviour
{
    // Start is called before the first frame update

    public void onclick()
    {
        SceneManager.LoadScene(1); // change scence
    }
}

