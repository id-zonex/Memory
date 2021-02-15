using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    [SerializeField] private Text _yCardCount;
    [SerializeField] private Text _xCardCount;

    [SerializeField] private int _datafullXValue;
    [SerializeField] private int _datafullYValue;

    private void Start()
    {
        PlayerPrefs.SetInt("xCardCount", _datafullXValue);
        PlayerPrefs.SetInt("yCardCount", _datafullYValue);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
        
    }

    public void TryGetCardCount()
    {
        int x = _datafullXValue;
        int y = _datafullYValue; 

        try
        {
            x = int.Parse(_xCardCount.text);
            y = int.Parse(_yCardCount.text);
        }
        catch (System.Exception)
        {
        }

        x = x <= 0 ? _datafullXValue : x;
        y = y <= 0 ? _datafullYValue : y;

        PlayerPrefs.SetInt("xCardCount", x);
        PlayerPrefs.SetInt("yCardCount", y);

        print(x);
        print(y);
    }
}
