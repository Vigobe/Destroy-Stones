using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InerfaceStone : MonoBehaviour
{
    public TMP_Text textThrown;
    public TMP_Text textDestroyed;
    public TMP_Text textTime;
    public TMP_Text textBest;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        textThrown.text = "Nro. Stones : " + GameManager.currentNumberStoneThrow;
        textDestroyed.text = "Destroy : " +  GameManager.currentNumberDestroyedStones ;
        textTime.text = "Time left : " + GameManager.currentTime.ToString("N0");
        textBest.text = "Best Score: " + GameManager.currentBestScore;

    }


}
