using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public Rigidbody2D rb;
    public float ballForce;
	// Use this for initialization
	void Start () {
        rb.AddForce(new Vector2(ballForce, ballForce));


    }

    // Update is called once per frame
    void Update ()
    {
        //If I don't want to move the ball
        //if (Input.GetKeyUp(KeyCode.Space)){
        //transform.SetParent(null);
        //    rb.AddForce(new Vector2(ballForce, ballForce));
        //}
            }
   
    }

