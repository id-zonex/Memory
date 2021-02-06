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
        PlayerPrefs.DeleteKey("xCardCount");
        PlayerPrefs.DeleteKey("yCardCount");
    }

    public void LoadGameAndTryGetCardCount()
    {
        TryGetCardCount();
        SceneManager.LoadSceneAsync(1);
        
    }

    private void TryGetCardCount()
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
