using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

    CodedSphere moveBall;
    Camera mainCamera;
    
    // Use this for initialization
	void Start () {


        moveBall = gameObject.GetComponent<CodedSphere>();
        mainCamera = gameObject.GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        {

            if (Input.GetMouseButtonDown(0))
            {

                moveBall.velocity = 9.8f * (1.8f * mainCamera.transform.forward);

            }


        }


    }
    }

