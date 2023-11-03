using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDie : MonoBehaviour
{
    private const float yDie= -30.0f;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y  < yDie)
            Destroy (gameObject);
    }

    void OnMouseDown()
    {
        Instantiate(explosion, transform.position,Quaternion.identity);
        Destroy(gameObject );
        GameManager.currentNumberDestroyedStones++;
        if (GameManager.currentNumberDestroyedStones > GameManager.currentBestScore)
        {
            GameManager.currentBestScore = GameManager.currentNumberDestroyedStones;
            GameManager.bestName = GameManager.namePlayer;
        }
    }
}
