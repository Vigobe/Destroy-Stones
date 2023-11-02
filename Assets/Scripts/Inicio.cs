using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public TMP_Text textBestScore;
    public void Update()
    {
        textBestScore.text = "Best Score: " + GameManager.currentBestScore;
    }
    public void Click()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
