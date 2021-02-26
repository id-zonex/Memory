using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneControler : MonoBehaviour
{
    [SerializeField] private List<GameObject> CardPrefabs = new List<GameObject>();
    [SerializeField] private CardInfo _cardInfo;

    [SerializeField] private int xOffSet;
    [SerializeField] private int yOffSet;
    
    private Camera _camera;

    private List<GameObject> _spawnedCards;

    private int xCardCount => PlayerPrefs.GetInt("xCardCount");
    private int yCardCount => PlayerPrefs.GetInt("yCardCount");

    private int cardsCount => xCardCount * yCardCount;


    void Start()
    {
        SpawnCards();
    }

    private void SpawnCards()
    {
        CardPrefabs = _cardInfo.GetCurrentCardPack(PlayerPrefs.GetInt("CurrentCardIndex")).Cards;

        _camera = Camera.main;
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

        _camera.transform.position = new Vector3(Mathf.Floor(width / 2) + 2, Mathf.Floor(heigth / 2) + 2f);

        _camera.orthographicSize = Mathf.Floor((width + heigth) / 2) * 0.4f;
    }

    private List<GameObject> RandomlyFillList(List<GameObject> cardPrefabs)
    {
        var cards = new List<GameObject>();

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

}
