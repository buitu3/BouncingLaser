using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastShoooter : MonoBehaviour, IPointerDownHandler
{
    public GameObject ball;
    public LineRenderer line;
	// Use this for initialization
	void Start () {
        line = this.GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        var dir = ball.transform.up;
        Debug.DrawRay(ball.transform.position, dir * 10, Color.green);
        line.SetPosition(0, ball.transform.position);
        line.SetPosition(1, dir * 10);
	}

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("clicked");
    }

}
