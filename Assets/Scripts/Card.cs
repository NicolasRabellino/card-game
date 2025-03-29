using System.Collections.Generic;
using UnityEngine;
public class Card : MonoBehaviour
{
    CardType type;
    BoxCollider2D col;
    SpriteRenderer sr;
    Vector3 startingPos;
    Vector3 playedPos;
    Vector3 mousePositionOffset;
    List<Collider2D> results;


    int index;
    int vialCost;
    bool colliding = false;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        results = new List<Collider2D>();
    }

    Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

    private void OnMouseDown()
    {
        if(!colliding) startingPos = transform.position;
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = Vector2.Lerp(transform.position, GetMouseWorldPosition() + mousePositionOffset, 12 * Time.deltaTime);
        if (!colliding && col.Overlap(results) > 0 ) // Si detecta mas de 0 colisiones es porque esta detectando el Playzone
        {
            transform.localScale *= 1.1f;
            HandManager.inst.playedCards.Add(this);
            colliding = true;
        }
        else if(colliding && col.Overlap(results).Equals(0))
        {
            transform.localScale /= 1.1f;
            HandManager.inst.playedCards.Remove(this);
            colliding = false;
        }
    }

    private void OnMouseUp()
    {
        //TODO: que te puedas arrepentir XD
        if(!colliding) transform.position = startingPos; // Si no detecta ninguna colision, volvemos a la mano
    }

}
