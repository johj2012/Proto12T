using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{ 
    [HideInInspector]
    public ItemProperty item;
    
    public UnityEngine.UI.Image image;

  

    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if(item==null)
        {
            image.enabled = false;
            Debug.Log(image.enabled);

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = item.name;
            image.sprite = item.sprite;
        }
    }

    public void OnPointerClick(PointerEventData eventData) // 아이템 슬롯을 클릭했을 시 실행
    {
       if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(item != null)
            {
                gameObject.GetComponent<Button>();

            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }
}
