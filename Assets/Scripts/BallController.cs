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
        //GetComponent<Rigidbody2D>().velocity = Speed * transform.up;
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

    public IEnumerator Move()
    {       
        while (true)
        {
            transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }    

    public void StartShooting(Vector2 mousePos)
    {
        var worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 shootDir = transform.position - worldMousePos;
        transform.up = shootDir;
        StartCoroutine(Move());
    }
}
