using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();  



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawCard(int x)
    {
        for(int i = 0; i < x-1; i++)
        {
            hand[hand.Count + 1] = deck[i];
            Debug.Log("matamos a este nigga" + deck[i]);
            deck.Remove(deck[i]);
            
        }

        Debug.Log(hand);
    }

    public void shuffleDeck()
    {
        Shuffle(deck);
        Debug.Log("niggers in my dickhole");

    }


    public void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        while (n > 1)
        {

            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
