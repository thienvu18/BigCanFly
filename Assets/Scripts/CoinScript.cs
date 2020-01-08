using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int coinValue;
    public MapLoad mapLoad;


    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        mapLoad = FindObjectOfType<MapLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        if(coinValue==0 && mapLoad.countSuperItem >= 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);

        }
        if (other.tag == "FallDetector")
        {
            Destroy(gameObject);
        }
    }
}
