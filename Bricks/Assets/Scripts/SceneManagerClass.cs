using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerClass : MonoBehaviour {
    public Text txtscore;
    
    public int globalScore = 0;
    private void Start()
    {
        // this gameobject and all children will
        // remain loaded when a new scene is loaded
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        SquareScript c = SquareScript.instance;
        if (c.cole)
        {
            c.cole = false;
            globalScore += 10;
            txtscore.text = (globalScore)+"";

            if (globalScore == 100 || globalScore == 360)
            {
                SceneManager.LoadScene("Scenes/Level2");

            }
            else if (globalScore == 230 || globalScore == 480)
            {
                SceneManager.LoadScene("Scenes/Level3");
            }
            
        }
    }
}
