using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public List<GameObject> CardPrefabs = new List<GameObject>();
    public List<Vector3> CardPositions = new List<Vector3>();

    private Card _firstRevealed;
    private Card _secondRevealed;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject CardPrefab = CardPrefabs[Random.Range(0, CardPrefabs.Count - 1)];
            Vector3 CardPosition = CardPositions[Random.Range(0, CardPositions.Count - 1)];

            Instantiate(CardPrefab).transform.position = CardPosition;

            CardPositions.Remove(CardPosition);
            CardPrefabs.Remove(CardPrefab);
        }
    }

    private int _store;
    public void CardRevealed(Card card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
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
    }
}
