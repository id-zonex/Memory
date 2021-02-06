using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Text _progres;
    private AsyncOperation operation;
    void Start()
    {
        operation = SceneManager.LoadSceneAsync(2);
    }

    
    void Update()
    {
        _progres.text = string.Format("{0}%", operation.progress * 100);
    }
}
