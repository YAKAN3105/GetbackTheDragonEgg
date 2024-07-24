using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class warningManager : MonoBehaviour
{
    
    Image fadeImage;
    float time = 0.0f;
    float fadeSpead = 1.0f;
    float alpha;

    GameObject cam;
     

    // Start is called before the first frame update
    void Start()
    {
        
        fadeImage = GetComponent<Image>();
        alpha = fadeImage.color.a;
        cam = BattleCameraController.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FadeIn()
    {
        if(cam.transform.position.y > 24)
        {
        //    fadeImage.color.
        }
    }
}
