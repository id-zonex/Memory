using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRestart : MonoBehaviour
{
    public void OnMouseUp()
    {
        SceneManager.LoadScene(0);
        
    }
}
