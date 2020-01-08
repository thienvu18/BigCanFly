using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperItems : MonoBehaviour
{
    public string item = "";
    public int type;
    public MapLoad mapLoad;
    //public List<CoinScript> coinList=new List<CoinScript>();
    // Start is called before the first frame update
    void Start()
    {
        mapLoad = FindObjectOfType<MapLoad>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (type == 1)
            {
                item = "shield";
                mapLoad.SetCountSuperItem();
            }
            Destroy(gameObject);

        }
        if (other.tag == "FallDetector")
        {
            Destroy(gameObject);
        }
    }

}
