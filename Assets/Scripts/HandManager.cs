using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager inst;
    public List<Card> playedCards;

    void Start()
    {
        inst = this;
    }

    public void PlayHand()
    {
        Card[] cardsInPlayZone = GetComponentsInChildren<Card>();
        foreach (Card card in cardsInPlayZone)
        {
            // hacer algo con la carta
        }
    }
    
    public void OnHandSizeChange()
    {

    }

}
