using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControler : MonoBehaviour
{
    [HideInInspector] public bool inProcces = false;

    [SerializeField] private GameObject[] CardPrefabs;
    private List<GameObject> Cards;

    private int xCardCount => PlayerPrefs.GetInt("xCardCount");
    private int yCardCount => PlayerPrefs.GetInt("yCardCount");

    private int cardsCount { get { return xCardCount * yCardCount; } }

    public bool canReveal { get { return _secondRevealed == null; } }

    [SerializeField] private int xOffSet;
    [SerializeField] private int yOffSet;

    private Card _firstRevealed;
    private Card _secondRevealed;

    private int _store;
    
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
                }
                index++;
            }

        }
        camera.transform.position = new Vector3(Mathf.Floor(width / 2) + 2, Mathf.Floor(heigth / 2) + 2f);

        camera.orthographicSize = Mathf.Floor((width + heigth) / 2) * 0.4f;

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

        cards = CardPlacer(cards);

        return cards;
    }

    private List<GameObject> CardPlacer(List<GameObject> cards)
    {
        System.Random rando = new System.Random();
        for (int i = cards.Count - 1; i >= 1; i--)
        {
            int j = rando.Next(i + 1);
            var temp = cards[j];
            cards[j] = cards[i];
            cards[i] = temp;
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
