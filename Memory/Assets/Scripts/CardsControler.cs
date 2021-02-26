using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


class CardsControler : MonoBehaviour
{

    [HideInInspector] public bool inProcces = false;

    [SerializeField] private UnityEvent AddScore;

    public static int _score;

    private Card _firstRevealed;
    private Card _secondRevealed;

    private void Start()
    {
        _score = 0;
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
            _score++;
            AddScore.Invoke();
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


[SerializeField]
class AddScoreEvent: UnityEvent
{

}

