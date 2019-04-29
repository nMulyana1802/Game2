using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float logoTime;
    private float minLogoTime = 3.0f;

	// Use this for initialization
	void Start () {

        // fadegroup di ambil dari canvasGroup yg ada di scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        // memberikan nilai alpha pada fadeGroup
        fadeGroup.alpha = 1;

        //memberikan waktu logo muncul
        if(Time.time < minLogoTime)
        {
            logoTime = minLogoTime;
        }
        else
        {
            logoTime = Time.time;
        }

	}
	
	// Update is called once per frame
	void Update () {

        // fade-in
        if (Time.time < minLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        // Fade-out
        if (Time.time > minLogoTime && logoTime != 0)
        {
            fadeGroup.alpha = Time.time - minLogoTime;
            if (fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }


}
