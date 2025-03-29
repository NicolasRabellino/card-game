using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject slotPrefab;
    public List<GameObject> deck;
    public Transform handTransform;
    public Transform slotTransform;
    public int currentDeckSize; // Lo obtenemos del gamemanager?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDeckSize = 7; // TEST
        createDeck(currentDeckSize);
    }

    void createDeck(int deckSize) // Se deberia llamar solo una vez por escena
    {
        for(int i = 0; i < deckSize; i++)
        {
            GameObject slot = Instantiate(slotPrefab, handTransform);
            slotTransform = slot.GetComponent<Transform>();
            GameObject card = Instantiate(cardPrefab, slotTransform); // despues hay que ordenarlo
            deck.Add(card);
            deck[i].GetComponent<Card>().SetCard((CardType)0, 1);
        }
    }

    void assingCardsToDeck()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            deck[i].GetComponent<Card>().SetCard(CardType.NONE, i);
        }
    }

    public void createNewCard()
    {

    }

    public void setCardActive(int index)
    {
        deck[index].SetActive(true);
    }
}



