using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Vectrosity;

public class RaycastShoooter : MonoBehaviour
{
    public int RayCount;
    public GameObject Ball;

    public Color LineColor;
    public Material LineMaterial;
    public Texture lineTexture;

    private float RayLength = 100f;
    private LineRenderer Line;
    private int WallLayer;
    private LayerMask WallMask;

    private VectorLine aimLine;

    void Start() {
        Line = this.GetComponent<LineRenderer>();
        WallLayer = LayerMask.NameToLayer("Block");
        WallMask = 1 << WallLayer;

        // Setup LineRenderer Color
        Line.startColor = LineColor;
        Line.endColor = LineColor;

        // Setup Vectrosity Line
        //aimLine = new VectorLine("aimLine", new List<Vector2>(), lineTexture, 2f, LineType.Continuous);
        //aimLine.SetColor(LineColor);
        //aimLine.material = LineMaterial;
    }

    void Update() {
        //var dir = Ball.transform.up;
        //Debug.DrawRay(Ball.transform.position, dir * 10, Color.green);
        //Line.SetPosition(0, Ball.transform.position);
        //Line.SetPosition(1, dir * 10);
    }

    public void DrawRay(Vector2 rayPos, Vector2 rayDir)
    {
        List<Vector2> ListPos = new List<Vector2>();

        // Raycast way

        //Debug.DrawRay(rayPos, rayDir * 100, Color.green);
        //ListPos.Add(rayPos);

        //RaycastHit2D hit = Physics2D.Raycast(rayPos, rayDir, 100, WallMask);
        ////var hits = Physics2D.RaycastAll(rayPos, rayDir, Mathf.Infinity, mask);
        //if (hit.collider != null)
        //{

        //    ListPos.Add(hit.point);

        //    //Debug.Log(hit.collider.gameObject.tag);
        //    Vector2 reflect = Vector2.Reflect(hit.point - rayPos, hit.normal);
        //    Debug.DrawRay(hit.point, reflect * 100, Color.blue);

        //    var start = hit.point;

        //    var hit2 = Physics2D.Raycast(hit.point, reflect, 100, WallMask);
        //    if (hit2.collider != null)
        //    {
        //        ListPos.Add(hit2.point);

        //        Debug.Log(hit2.point);
        //        reflect = Vector2.Reflect(hit2.point - start, hit2.normal);
        //        Debug.DrawRay(hit2.point, reflect * 100, Color.red);
        //    }
        //}

        // RaycastAll way 
        for (int i = 0; i < RayCount; i++)
        {
            ListPos.Add(rayPos);
            Debug.DrawRay(rayPos, rayDir * RayLength, Color.green);
            RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, rayDir, RayLength, WallMask);

            rayDir = Vector2.Reflect(hits[0].point - rayPos, hits[0].normal);
            rayPos = hits[0].point;
        }
        ListPos.Add(rayPos);

        Line.positionCount = ListPos.Count;
        // Draw linerenderer
        for (int i = 0; i < ListPos.Count; i++)
        {
            Line.SetPosition(i, ListPos[i]);
        }

        // Using Vectrosity line
        //for (int i = 0; i < RayCount; i++)
        //{
        //    ListPos.Add(rayPos);
        //    Debug.DrawRay(rayPos, rayDir * RayLength, Color.green);
        //    RaycastHit2D[] hits = Physics2D.RaycastAll(rayPos, rayDir, RayLength, WallMask);

        //    rayDir = Vector2.Reflect(hits[0].point - rayPos, hits[0].normal);
        //    rayPos = hits[0].point;
        //}
        //ListPos.Add(rayPos);

        //for (int i = 0; i < ListPos.Count; i++)
        //{
        //    ListPos[i] = Camera.main.WorldToScreenPoint(ListPos[i]);
        //}

        //aimLine.points2 = ListPos;
        ////aimLine.points2.Clear();
        //aimLine.Draw();
    }

    public void EnableRay()
    {
        Line.enabled = true;
    }

    public void DisableRay()
    {
        Line.enabled = false;
    }
}
