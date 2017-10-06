using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public Camera mainCamera;
    public Camera overheadCamera;

	// Use this for initialization
	void Start () {

        mainCamera.enabled = true;
        overheadCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            mainCamera.enabled = !mainCamera.enabled;
            overheadCamera.enabled = !overheadCamera.enabled;

        }
		
	}
}
