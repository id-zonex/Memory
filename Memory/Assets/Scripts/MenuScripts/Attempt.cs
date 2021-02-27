using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Attempt : MonoBehaviour
{
    [SerializeField] private SceneControler _sceneControler;

    private Text _text;

    private int _attempts;
    private int getStartAttempts => Mathf.CeilToInt(_sceneControler.cardsCount / 2) * 2;


    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = getStartAttempts.ToString();

        _attempts = getStartAttempts;
    }

    public void OnMakeAttempt()
    {
        _attempts -= 1;

        if (_attempts <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        _text.text = _attempts.ToString();
    }

}
