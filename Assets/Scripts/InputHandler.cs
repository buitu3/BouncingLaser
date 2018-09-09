using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour,IPointerDownHandler {

    public BallController ballController;

    public void OnMouseDown()
    {
        Debug.Log("pressed");
    }

    public void OnPointerDown(PointerEventData data)
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        ballController.HandlingMousePressed(mousePos);
    }
}
