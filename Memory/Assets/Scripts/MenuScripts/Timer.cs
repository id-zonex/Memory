using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTime;

    private Text _timerText;

    private void Start()
    {
        _timerText = GetComponent<Text>();
        _timerText.text = _startTime.ToString();
    }

    private void Update()
    {
        if (_startTime <= 0) TimeHasPassed();

        _startTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(_startTime).ToString();
    }

    private void TimeHasPassed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
