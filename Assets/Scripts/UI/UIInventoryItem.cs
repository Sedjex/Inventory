using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityTxt;
    [SerializeField] private Image borderImage;
    public event Action<UIInventoryItem> OnItemClicked,
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;
    
    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    private void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    private void Deselect()
    {
        borderImage.enabled = false;
    }
    
    public void Select()
    {
        borderImage.enabled = true;
    }
    
    public void SetData(Sprite sprite, int quantity)
    {
     this.itemImage.gameObject.SetActive(true);
     this.itemImage.sprite = sprite;
     this.quantityTxt.text = quantity + " ";
     empty = false;
    }

    public void OnBeginDrag()
    {
        if(empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        if(empty)
            return;
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
