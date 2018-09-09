using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour {

    public int Lives;
    public float Speed;

    private Vector2 Direction;
    private bool reflecting = false;

	// Use this for initialization
	void Start () {
    }

    void Update()
    {
        // transform style
        //transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);        
    }

    private void FixedUpdate()
    {
        //if (reflecting)
        //{
        //    reflecting = false;
        //}

        // Move laser in velocity style
        GetComponent<Rigidbody2D>().velocity = Speed * transform.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        reflecting = true;
        ContactPoint2D contact = collision.contacts[0];
        var reflectedDir = Vector2.Reflect(transform.up, contact.normal);

        transform.up = reflectedDir;

        //if (collision.gameObject.CompareTag("Wall") && !reflecting)
        //{
            
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Wall") && reflecting)
        //{
        //    reflecting = false;
        //}
    }

    public void HandlingMousePressed(Vector2 mousePos)
    {
        Vector2 ballPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (mousePos - ballPos).normalized;
        transform.up = direction;        
        Direction = direction;
    }

    public IEnumerator Move(Vector2 direction)
    {       
        while (true)
        {
            transform.Translate(transform.up * Time.deltaTime, Space.World);
            yield return null;
        }
    }    

}
