using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inventory", menuName="Inventory", order=1)]
public class CardInfo : ScriptableObject
{
    public CardPack DatafullCardPack;

    public List<CardPack> OpenCads;
    public List<CardPack> AllCards = new List<CardPack>();


    public CardPack GetCurrentCardPack(int index)
    {
        foreach (var i in OpenCads)
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

        OpenCads.Clear();
        OpenCads.Add(DatafullCardPack);
    }

}
