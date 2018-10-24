using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public BallController ballController;
    public RaycastShoooter rayShooter;

    private bool isAimMove = false;
    private int InputLayer;
    private LayerMask InputMask;

    public void Start()
    {
        InputLayer = LayerMask.NameToLayer("Input");
        InputMask = 1 << InputLayer;
    }

    public void Update()
    {
        if (isAimMove)
        {
            Vector2 dir = ballController.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.DrawRay(ballController.transform.position, dir * 100, Color.green);

            rayShooter.DrawRay(ballController.transform.position, dir);
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        // Raycast Style
        //RaycastHit2D[] hits = null;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //hits = Physics2D.RaycastAll(ray.origin, ray.direction, 100f);

        //var hitCount = Physics2D.RaycastNonAlloc(ray.origin, ray.direction, hits, 100f);
        //if (hits.Length > 0)
        //{            
        //    foreach (var hitObject in hits)
        //    {
        //        if (hitObject.transform.gameObject.CompareTag("Ball"))
        //        {
        //            isAimMove = true;
        //        }
        //    }
        //}

        // Overlap point Style
        var collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), InputMask);
        if (collider != null && collider.gameObject.CompareTag("FireStart"))
        {
            isAimMove = true;
            rayShooter.EnableRay();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        isAimMove = false;
        rayShooter.DisableRay();
    }
}
