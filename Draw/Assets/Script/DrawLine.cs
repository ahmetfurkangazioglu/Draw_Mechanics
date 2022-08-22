using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject LinePrefab;
    [HideInInspector] public List<GameObject> DrawClone;
    [HideInInspector] public  List<Vector2> FingerPosList;
    GameObject Draw;
    LineRenderer _lineRenderer;
    EdgeCollider2D _EdgeCollider;
   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateDraw();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 FingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(FingerPos, FingerPosList[^1]) > .1f)
            {
                UpdateDraw(FingerPos);
            }
        }
    }
    void CreateDraw()
    {
        Draw = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        DrawClone.Add(Draw);
        _lineRenderer = Draw.GetComponent<LineRenderer>();
        _EdgeCollider = Draw.GetComponent<EdgeCollider2D>();
        FingerPosList.Clear();
        FingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        FingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _lineRenderer.SetPosition(0, FingerPosList[0]);
        _lineRenderer.SetPosition(1, FingerPosList[1]);
        _EdgeCollider.points = FingerPosList.ToArray();
    }
    void UpdateDraw(Vector2 FingerPos)
    {
        FingerPosList.Add(FingerPos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, FingerPos);
        _EdgeCollider.points = FingerPosList.ToArray();
    }


    public void ShotControl()
    {
        foreach (var item in DrawClone)
        {
            Destroy(item.gameObject);
        }
        DrawClone.Clear();
    }

}
