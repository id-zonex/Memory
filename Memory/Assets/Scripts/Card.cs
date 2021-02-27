using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int CardID;
    public GameObject main;
    public GameObject CardBeck;

    public CardType type = CardType.NormalCard;

    [SerializeField] private CardsControler CardsControler;

    private void Start()
    {
        main = GameObject.Find("SceneControler");
        CardsControler = main.GetComponent<CardsControler>();
    }


    public void OnMouseDown()
    {
        if (CardBeck.activeSelf)
        {
            if (CardsControler.inProcces) return;

            CardBeck.SetActive(false);
            CardsControler.CardRevealed(this);
        }
    }

    public enum CardType
    {
        NormalCard,
        CoinCard,
    }

    public void Unreveal()
    {
        if (CardBeck != null) CardBeck.SetActive(true);
    }

    public void UpCoin()
    {

    }
}
