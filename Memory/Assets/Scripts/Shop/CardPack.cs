using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPack : MonoBehaviour
{
    public bool IsSelected;
    public bool IsBuy;

    public List<GameObject> Cards;
    public Card Coin;

    public int index;

    [SerializeField] private int _price;
    [SerializeField] private CardInfo _cardsInfo;

    [SerializeField] private Text _buttonText;

    [SerializeField] private string _selectText;
    [SerializeField] private string _deSelectText;


    private void Start()
    {
        if(index == PlayerPrefs.GetInt("CurrentCardIndex"))
        {
            print(PlayerPrefs.GetInt("CurrentCardIndex"));
            IsSelected = true;
        }

        if (IsSelected)
        {
            Select();
        }
    }

    public void Select()
    {
        _cardsInfo.GetCurrentCardPack(PlayerPrefs.GetInt("CurrentCardIndex")).Deselect();
        PlayerPrefs.SetInt("CurrentCardIndex", index);   
        IsSelected = true;
        DeselectAll();
        _buttonText.text = _selectText;
    }

    public void Deselect()
    {
        IsSelected = false;
        _buttonText.text = _deSelectText;
    }

    private void DeselectAll()
    {
        Transform parent = transform.parent;

        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i).gameObject.GetComponent<CardPack>();

            if (child.IsBuy)
            {   
                if (child != this)
                {
                    print(parent.GetChild(i).gameObject.GetComponent<CardPack>().IsSelected);
                    child.Deselect();
                }
            }
        }
    }

    public void Buy()
    {
        _cardsInfo.OpenCads.Add(this);
    }
}
