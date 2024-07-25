using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class warningManager : MonoBehaviour
{
    
    Image fadeImage;
    float time = 0.0f;
    float fadeSpead = 1.0f;
    CanvasGroup Transparency;
    bool isFadewarning = false;

    Transform cam;
     

    // Start is called before the first frame update
    void Start()
    {
        Transparency = GetComponent<CanvasGroup>();
        fadeImage = GetComponent<Image>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (cam.transform.position.y > 24)
        {
            StartCoroutine(FadeIn());
            
            Debug.Log("test");
        }
    }
    IEnumerator FadeIn() // if(cam.transform.position.y > 24)‚ð–ž‚½‚µ‚Ä‚¢‚é‚Æ‚«‚ÉŒÄ‚Î‚ê‚é‘z’è
    {
        Transparency.alpha += 0.01f; 
        yield return new WaitForSeconds(Time.deltaTime); 
    }
}
