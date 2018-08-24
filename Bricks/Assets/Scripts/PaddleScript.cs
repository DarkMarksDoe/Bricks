using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;
    public float MaxX;
    public float MaxY;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("up")) {
            print("up key was pressed");
            rb.velocity = new Vector2(0, +speed);
        }else if (Input.GetKeyDown("down")) {
            print("down key was pressed");
            rb.velocity = new Vector2(0, -speed);
        } else if (Input.GetKeyDown("right"))
        {
            print("right key was pressed");
            rb.velocity = new Vector2(+speed, 0);
        }else if (Input.GetKeyDown("left"))
        {
            print("left key was pressed");
            rb.velocity = new Vector2(-speed, 0);
        }
        ////////RESTRICTED AREA//////////
        Vector3 pos = transform.position;
        pos.x=Mathf.Clamp(pos.x,-MaxX, +MaxX);
        pos.y=Mathf.Clamp(pos.y, -MaxY, +MaxY);
        transform.position = pos;
    }  
}
