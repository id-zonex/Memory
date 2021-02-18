using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControler : MonoBehaviour
{
    [HideInInspector] public bool inProcces = false;

    [SerializeField] private List<GameObject> CardPrefabs = new List<GameObject>();
    [SerializeField] private CardInfo _cardInfo;

    private List<GameObject> _spawnedCards;

    private int xCardCount => PlayerPrefs.GetInt("xCardCount");
    private int yCardCount => PlayerPrefs.GetInt("yCardCount");

    private int cardsCount { get { return xCardCount * yCardCount; } }

    public bool CanReveal { get { return _secondRevealed == null; } }

    [SerializeField] private int xOffSet;
    [SerializeField] private int yOffSet;

    private Card _firstRevealed;
    private Card _secondRevealed;

    private int _store;
    
    private Camera camera;

    void Start()
    {
        CardPrefabs = _cardInfo.GetCurrentCardPack(PlayerPrefs.GetInt("CurrentCardIndex")).Cards;

        camera = Camera.main;
        _spawnedCards = RandomlyFillList(CardPrefabs);
       

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
                    var card = Instantiate(_spawnedCards[index], new Vector3(Xoff, yOff, 10), Quaternion.identity);
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

    private List<GameObject> RandomlyFillList(List<GameObject> cardPrefabs)
    {
        var cards = new List<GameObject>();
        print(cards);
        print(cardPrefabs);

        while(true)
        {
            if (cards.Count + 2 > cardsCount) break;
            var randElement = cardPrefabs[Random.Range(0, cardPrefabs.Count)];

            cards.Add(randElement.gameObject);
            cards.Add(randElement.gameObject);
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
