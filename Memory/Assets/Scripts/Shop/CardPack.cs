using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPack : MonoBehaviour
{
    public bool IsSelected;
    public List<GameObject> Cards;

    [SerializeField] private int index;

    [SerializeField] private int _price;
    [SerializeField] private CardInfo _cardsInfo;

    [SerializeField] private Text _buttonText;

    [SerializeField] private string _selectText;
    [SerializeField] private string _deSelectText;

    [SerializeField] private CardPack card;

    private void Start()
    {
        if(gameObject.name == _cardsInfo.CurrentCardPackName)
        {
            IsSelected = true;
        }

        if (IsSelected)
        {
            Select();
        }
    }

    public void Select()
    {
        _cardsInfo.GetCardPackByName().Deselect();
        _cardsInfo.CurrentCardPackName = gameObject.name;
        _cardsInfo.CurrentCardIndex = index;
        IsSelected = true;
        _buttonText.text = _selectText;
    }

    public void Deselect()
    {
        IsSelected = false;
        _buttonText.text = _deSelectText;
    }

    public void Buy()
    {
        _cardsInfo.OpenCads.Add(this);
    }
}
