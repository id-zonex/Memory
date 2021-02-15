using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inventory", menuName="Inventory", order=1)]
public class CardInfo : ScriptableObject
{
    public CardPack DatafullCardPack;

    public CardPack CurrentCardPack;
    public List<CardPack> OpenCads;

    public int CurrentCardIndex;
    public string CurrentCardPackName;

    public CardPack GetCurrentCardPack()
    {
        return OpenCads[CurrentCardIndex];
    }

    public CardPack GetCardPackByName()
    {
        return GameObject.Find(CurrentCardPackName).GetComponent<CardPack>();
    }


    public void Reset()
    {
        CurrentCardPack = DatafullCardPack;

        OpenCads.Clear();
        OpenCads.Add(DatafullCardPack);
    }

}
