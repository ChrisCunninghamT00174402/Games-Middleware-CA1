using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft;
    public Text counterText;

	// Use this for initialization
	void Start () {

        counterText = GetComponent<Text>();
      
	}

    // Update is called once per frame
     public void Update()
    {
        timeLeft -= Time.deltaTime;

        counterText.text = timeLeft.ToString("0");

        if (timeLeft <= 0)
        {

            //UnityEditor.EditorApplication.isPlaying = false;
            
        }
     

    }

}


