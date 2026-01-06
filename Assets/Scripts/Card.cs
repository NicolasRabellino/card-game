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
    private Vector2 targetAnchoredPosition;
    private Vector2 ogAnchoredPosition;
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

    private void Update()
    {
        if(isDragging)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(
                rectTransform.anchoredPosition,
                targetAnchoredPosition,
                smoothSpeed * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        ogAnchoredPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        targetAnchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        canvasGroup.blocksRaycasts = true;
        
        GameObject objectUnderMouse = eventData.pointerCurrentRaycast.gameObject;
        
        if (objectUnderMouse != null && objectUnderMouse.name == "PlayCardSpot")
        {
            transform.SetParent(objectUnderMouse.transform);
            rectTransform.localPosition = Vector3.zero;
        }
        else
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = ogAnchoredPosition;
        }
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
