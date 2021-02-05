using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int CardID;
    public GameObject main;
    public GameObject CardBeck;
    SceneControler SceneControler;

    void Start()
    {
        main = GameObject.Find("SceneControler");
        SceneControler = main.GetComponent<SceneControler>();
    }


    private void OnMouseDown()
    {
        if (CardBeck.activeSelf)
        {
            if (SceneControler.inProcces) return;

            CardBeck.SetActive(false);
            SceneControler.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        CardBeck.SetActive(true);
    }
}
