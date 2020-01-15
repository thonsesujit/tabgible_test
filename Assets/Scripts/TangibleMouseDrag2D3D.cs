using UnityEngine;
using UnityEngine.EventSystems;
using TE;
using System;
using Assets.Scripts;


/// <summary>
/// This script is to drag any game object with Tangible disc. Add directly to your game object
/// </summary>

public class TangibleMouseDrag2D3D : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Vector2 _initialPosition;
    public Vector3 _finalPosition;
    public float Xpos;
    public float Ypos;
    public float TangibleOffsetX;
    public float TangibleOffsetY;
 

    private void Start()
    {
        TangibleEngine.OnTangibleAdded += InitialPosition;
    }
    private void Update()
    {
        TangibleEngine.OnTangibleAdded += HandleOnTangibleAdded;
        TangibleEngine.OnTangibleUpdated += HandleOnTangibleUpdated;
        TangibleEngine.OnTangibleRemoved += HandleOnTangibleRemoved;
    }

    private void HandleOnTangibleAdded(Tangible obj)
    {

    }
    private void HandleOnTangibleUpdated(Tangible obj)
    {
        MoveMenuWithTangible(obj);
    }

    private void HandleOnTangibleRemoved(Tangible obj)
    {

    }

    public void MoveMenuWithTangible(Tangible obj)
    {


        if (this != null) { 
            if (this.name == obj.PatternId.ToString())
            
                {

                    Xpos = Mathf.Clamp(obj.X + TangibleOffsetX, 0, Screen.width);
                    Ypos = Mathf.Clamp(obj.Y + TangibleOffsetY, 0, Screen.height);

                    _finalPosition = new Vector3(Xpos + 10, Ypos + 10, 0);
                    this.transform.position = _finalPosition;
                
                }
            }

    }


    public static GameObject itemBeginDragged;  // you can select one object at a time to drag
    Vector3 startPosition;
    Transform startParent;

    float distance = 10;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDragged = gameObject; //current game obj
        startPosition = transform.position;
        startParent = transform.parent;  // if the obj is being droped to new slot

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeginDragged = null;
        if (transform.parent != startParent)
        {
            transform.position = startPosition;   // will bounce back to start position
        }

    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public void InitialPosition(Tangible obj)
    {
        _initialPosition = obj.Pos;
    }

}