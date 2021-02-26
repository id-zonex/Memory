using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int CardID;
    public GameObject main;
    public GameObject CardBeck;

    [SerializeField] private CardsControler CardsControler;

    void Start()
    {
        main = GameObject.Find("SceneControler");
        CardsControler = main.GetComponent<CardsControler>();
    }


    private void OnMouseDown()
    {
        if (CardBeck.activeSelf)
        {
            if (CardsControler.inProcces) return;

            CardBeck.SetActive(false);
            CardsControler.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        CardBeck.SetActive(true);
    }
}
