using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTime;

    private Text _timerText;

    void Start()
    {
        _timerText = GetComponent<Text>();
        _timerText.text = _startTime.ToString();
    }

    void Update()
    {
        if (_startTime <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        _startTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(_startTime).ToString();
    }
}
