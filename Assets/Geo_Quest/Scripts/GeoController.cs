using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GeoController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 3;
    public string nextLevel = "Scene_2";
    private SpriteRenderer square;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        square = GetComponentInChildren<SpriteRenderer>();
    }

    
    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xSpeed * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            square.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            square.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            square.color = Color.blue;
        }
    }
    //    private void OnCollisionEnter2D(Collision2D collision)
    //{
      //  Debug.Log("Hit");
    //}

       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
    
        }

    }






    //rb.velocity = new Vector2(-1, rb.velocity.y);
    // print(var1);
    //var1++;
    //transform.position += new Vector3(0.0005f, 0, 0);

    //if (Input.GetKeyDown(KeyCode.W)  || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Mouse0)) 
    //{ 
    //transform.position += new Vector3(0, 1, 0);
    //}

    //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    //{
    //    transform.position += new Vector3(-1, 0, 0);
    //}

    //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
    //{
    //    transform.position += new Vector3(0, -1, 0);
    //}

    //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    //{
    //   transform.position += new Vector3(1, 0, 0);
    //}


}