using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public bool checkBoomDestroy = false;
    public PlayerController gamePlayer;
    private Animator boomAnimation;
    // Start is called before the first frame update
    void Start()
    {
        boomAnimation = GetComponent<Animator>();
        gamePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkBoomDestroy)
        {
            BoomDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //gamePlayer.live--;
            //gamePlayer.SetPlayerText();
            checkBoomDestroy = true;
        }
    }

    public void BoomDestroy()
    {
        StartCoroutine("BoomDestroyCoroutine");
    }


    public IEnumerator BoomDestroyCoroutine()
    {
        boomAnimation.SetBool("BoomDestroy", true);
        yield return new WaitForSeconds(0);
        Destroy(gameObject);
    }
}
