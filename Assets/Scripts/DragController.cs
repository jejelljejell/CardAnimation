using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    public static GameObject itemBeginDragged;
    Vector3 startPosition;
    Transform startParent;

    
    // OnBeginDrag - 드래그 할때 처음 한번 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent; //slot name will be returned
        /* 
         * Raycast - 공간의 특정 지점에서 특정 방향 거리 안에 게임 오브젝트가 존재하는지 판별
         * blockRaycast - Canvas가 Raycast와 충돌이 가능하게함 
         */
         // GetComponent<CanvasGroup>().blocksRaycasts = true로 하면 카드 드래그해서 슬롯에 둘 수 없음
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // OnDrag - 드래그 동안 마우스 커서가 움직일때마다 호출
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // OnEndDrag - 드래그 종료시 한번 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeginDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

    }

}
