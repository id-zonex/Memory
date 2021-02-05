using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControler : MonoBehaviour
{
    [HideInInspector] public bool inProcces = false;

    public GameObject[] CardPrefabs;
    private List<GameObject> Cards;
    
    public int xCardCount;
    public int yCardCount;

    private int cardsCount
    {
        get { return xCardCount * yCardCount; }

    }

    public int xOffSet;
    public int yOffSet;

    private Card _firstRevealed;
    private Card _secondRevealed;

    private int _store;

    public bool canReveal 
    { 
        get { return _secondRevealed == null; } 
    }

    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        Cards = RandomlyFillList(CardPrefabs);
        float yOff = 0;

        float width = xCardCount * xOffSet;
        float heigth = yCardCount * yOffSet;
        var index = 0;
        for (int y = 0; y < yCardCount; y++)
        {

            yOff += yOffSet;
            float Xoff = 0;
            for (int x = 0; x < xCardCount; x++)
            {
                Xoff += xOffSet;
                try
                {
                    var card = Instantiate(Cards[index], new Vector3(Xoff, yOff, 10), Quaternion.identity);
                }
                catch (System.Exception)
                {
                    break;
                    throw;
                }
                index++;
            }

        }
        print(new Vector3((width / 2), (heigth / 2) + 2.8f));
        camera.transform.position = new Vector3((width / 2), (heigth / 2) + 2.8f);
        
        camera.orthographicSize = Mathf.Floor(heigth / 2);
        print(camera.orthographicSize);

    }

    private List<GameObject> RandomlyFillList(GameObject[] cardPrefabs)
    {
        var cards = new List<GameObject>();

        while(true)
        {
            if (cards.Count + 2 > cardsCount) break;
            var randIndex = Random.Range(0, cardPrefabs.Length);

            cards.Add(cardPrefabs[randIndex]);
            cards.Add(cardPrefabs[randIndex]);
        }

        return cards;
    }

    public void CardRevealed(Card card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            inProcces = true;
            _secondRevealed = card;
            CheckMatch();
        }
    }

     private void CheckMatch()
     {
        if (_firstRevealed.CardID == _secondRevealed.CardID)
        {
            _store++;
        }

        else
        {
            Invoke("ReCard", 0.5f);
        }

        Invoke("NullCard", 0.6f);
     }

    public void ReCard()
    {
        _firstRevealed.Unreveal();
        _secondRevealed.Unreveal();
    }

    public void NullCard()
    {
        _firstRevealed = null;
        _secondRevealed = null;

        inProcces = false;
    }

}
