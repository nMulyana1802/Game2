using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour {

    public Transform[] background; // data background yang akan bergeser
    private float[] parralaxScale; // proposisi kamera
    public float smooth = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start() {

        previousCamPos = cam.position;

        parralaxScale = new float[background.Length];
        for (int i = 0; i < background.Length; i++)
        {
            parralaxScale[i] = background[i].position.z * -1;
        }

	}
	
	// Update is called once per frame
	void Update () {

        for(int i =0; i< background.Length; i++)
        {

            float parallax = (previousCamPos.x - cam.position.x) * parralaxScale[i];

            float backgroundTargetPosX = background[i].position.x + parallax ;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, background[i].position.y, background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smooth * Time.deltaTime);

        }

        previousCamPos = cam.position;

	}
}
