using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inventory", menuName="Inventory", order=1)]
public class CardInfo : ScriptableObject
{
    public CardPack DatafullCardPack;

    public List<int> OpenCardsIndex;
    public List<CardPack> OpenCards;
    public List<CardPack> AllCards;


    public CardPack GetCurrentCardPack(int index)
    {
        foreach (var i in OpenCards)
        {
            if (i.index == PlayerPrefs.GetInt("CurrentCardIndex"))
            {
                return i;
            }
        }

        return null;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("CurrentCardIndex");

        OpenCards.Clear();
        OpenCards.Add(DatafullCardPack);
    }

}
