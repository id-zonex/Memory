using UnityEngine;
using UnityEngine.Events;


class CardsControler : MonoBehaviour
{

    [HideInInspector] public bool inProcces = false;

    [SerializeField] private UnityEvent AddScore;
    [SerializeField] private UnityEvent MakeAttempt;

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
            CheckCardType(card);
            _firstRevealed = card;
        }
        else
        {
            inProcces = true;
            _secondRevealed = card;
            CheckMatch();
            CheckCardType(card);
        }
    }

    private void CheckMatch()
    {
        if (_firstRevealed.CardID == _secondRevealed.CardID)
        {
            _score++;
        }
        else
        {
            MakeAttempt.Invoke();
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

    private void CheckCardType(Card card)
    {
        if (card.type == Card.CardType.CoinCard)
        {
            card.UpCoin();
            Destroy(card.gameObject, 0.3f);
        }
    }
}
