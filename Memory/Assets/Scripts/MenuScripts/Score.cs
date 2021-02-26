using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetScore()
    {
        text.text =  CardsControler._score.ToString();
    }
}
