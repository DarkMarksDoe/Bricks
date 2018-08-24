using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareScript : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject newBall;
    public GameObject tempBall;
    public float speed;
    public float MaxX;
    public float MaxY;
    public float score = 0;
  public bool cole = false;

    public static SquareScript instance = null;
    // Use this for initialization
    private void Awake()
    {
        instance=this;
    }
    void Start() {
        
        //print("1");
        tempBall = newBall;
           }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("up")) {
            rb.velocity = new Vector2(0, +speed);
        }else if (Input.GetKeyDown("down")) {
            rb.velocity = new Vector2(0, -speed);
        } else if (Input.GetKeyDown("right"))
        {
            rb.velocity = new Vector2(+speed, 0);
        }else if (Input.GetKeyDown("left"))
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        ////////RESTRICTED AREA//////////
        Vector3 pos = transform.position;
        pos.x=Mathf.Clamp(pos.x,-MaxX, +MaxX);
        pos.y=Mathf.Clamp(pos.y, -MaxY, +MaxY);
        transform.position = pos;
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball"){
            Destroy(col.gameObject); 
            SpawnBall();
            cole = true;
        }
        else
        {
            cole = false;
        }

    }
    void SpawnBall(){
        // print("Is created");
        // Defines the min and max ranges for x and y
        Vector2 position = new Vector2(Random.Range(-MaxX, +MaxX), Random.Range(-MaxY, +MaxY));
        //Random force when spawn the ball
        Vector2 forceBall = new Vector2(Random.Range(50, 400), Random.Range(50, 400));
        tempBall = Instantiate(tempBall, position, Quaternion.identity) as GameObject;
         Rigidbody2D rd = tempBall.GetComponent<Rigidbody2D>();
        rd.AddForce(forceBall);
        tempBall.AddComponent<CircleCollider2D>().enabled = true;
    }
}
