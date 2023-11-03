using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public TMP_Text textBestScore;
    public TMP_InputField inputName;
    public TMP_Text textName;

   
    public void Update()
    {
        textBestScore.text = "Best Score: " + GameManager.bestName + " = " + GameManager.currentBestScore;
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

    public void GetName()
    {
        textName.text = inputName.text;
        GameManager.namePlayer  = textName.text;
        Debug.Log(textName.text);
    }
}
