using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int coins;
    public Text coinText;
    public Text coinTextEndGame;
    public MapLoad mapLoad;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "     : " + coins;
        coinTextEndGame.text = "     : " + coins;
        mapLoad = FindObjectOfType<MapLoad>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int numberOfCoins)
    {
        if (mapLoad.countCoinx2 == 0)
        {
            coins += numberOfCoins;
            coinText.text = "     : " + coins;
            coinTextEndGame.text = "     : " + coins;
        }
        else if (mapLoad.countCoinx2 >= 0)
        {
            Debug.Log("đã nhân hai số điểm, countcoin" +mapLoad.countCoinx2);
            coins += numberOfCoins*2;//số hai là số nhân
            coinText.text = "     : " + coins;
            coinTextEndGame.text = "     : " + coins;
        }
    }
}
