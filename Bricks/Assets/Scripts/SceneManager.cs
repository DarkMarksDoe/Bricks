using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour {
    public Text txtscore;
    
    public int globalScore = 0;
    private void Start()
    {
     
    }

    public void Update()
    {
        SquareScript c = SquareScript.instance;
        if (c.cole)
        {
            globalScore += 10;
            txtscore.text = (globalScore)+"";

        }
        c.cole = false;
        if (globalScore == 50)
        {
            Application.LoadLevel("Level2");

        }
        else if (globalScore == 100)
        {
            Application.LoadLevel("Level3");
        }

    }
}
