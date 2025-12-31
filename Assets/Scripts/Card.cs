using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Camera meinCampf;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Transform originalParent;
    private Vector3 offset;
    private Vector3 targetPosition;
    private bool isDragging = false;

    private float smoothSpeed = 15f;

    CardType type;
    BoxCollider2D col;
    SpriteRenderer sr;

    int index;
    int vialCost;
    bool colliding = false;
    private void Awake()
    {
        meinCampf = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        targetPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject objectUnderMouse = eventData.pointerCurrentRaycast.gameObject;

        if (objectUnderMouse != null && objectUnderMouse.name == "PlayCardSpot")
        {
            transform.SetParent(objectUnderMouse.transform);
        }
        else
        {
            transform.SetParent(originalParent);
        }

        // Reset crítico para que la carta no se pierda en el espacio
        transform.localPosition = Vector3.zero;
        // Forzamos Z a 0 para que sea visible
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchoredPosition3D = new Vector3(rt.anchoredPosition3D.x, rt.anchoredPosition3D.y, 0);
    }

    void LoadCardSprite()
    {
        Sprite sprite = Resources.Load<Sprite>($"Sprites/Cards/{type}_{index}");
        sr.sprite = sprite;
    }

    public void GetCard()
    {
        Debug.Log($"type:{type} index:{index}");
    }
    public void SetCard(CardType t, int i)
    {
        type = t;
        index = i;
        Debug.Log($"{type}_{index}");
        LoadCardSprite();
    }
    public void CardEffect()
    {
        if(type == CardType.NONE)
        {
            if(index == 0) // Escudo
            {
                vialCost = 0;

            }
        }
    }

    
}
