using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewsTab : MonoBehaviour
{
    // Start is called before the first frame update
    public void onclick()
    {
        SceneManager.LoadScene(3); // change scence
    }
}
