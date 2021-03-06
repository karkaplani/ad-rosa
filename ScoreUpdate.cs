using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();    
    }

    void Update()
    {
        if(this.gameObject.tag == "EndScore") 
        {
            scoreText.text = SkullBehaviour.score + " COR";
        }
        else scoreText.text = "x" + SkullBehaviour.score; 
    }
}
