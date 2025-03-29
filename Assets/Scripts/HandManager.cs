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
        for (int i = 0; i < playedCards.Count; i++)
        {
            Debug.Log($"played card: {playedCards[i]}");
        }
    }
    
    public void OnHandSizeChange()
    {

    }

}
