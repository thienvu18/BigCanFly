using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;

public class MapLoad : MonoBehaviour
{
    public Transform coin3;//-7.5f->7.5f
    public Transform coin5;//-7.5f->7.5f
    public Transform trapMilkTea;//-6.2f->6.2f
    public Transform trapIce;//-7f->6.5f
    public Transform coin1;//-7.5f->7.5f

    //mapload
    public Transform Grass1;
    public Transform Grass2;
    public Transform Grass3;
    public Transform Grass4;
    public Transform Grass5;

    public PlayerController gamePlayer;
    private int countTime = 0;
    private int countLevel = 1;
    public int countSuperItem = 0;
    //biến đếm thời gian có hiệu lực của khiên
    private int countShield;

    // Start is called before the first frame update
    void Start()
    {
        //line[0]: khiên
        string[] lines = File.ReadAllLines("Assets//Scripts//SupperItem.txt");
        countShield = int.Parse(lines[0]);
    }

    // Update is called once per frame
    void Update()
    {
        countTime++;
        Transform t = null;
        //mapload cây cỏ
        if(countTime== Random.Range(countTime, countTime + 700))
        {
            t = Instantiate(Grass1, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), Grass1.rotation) as Transform;
        }
        if (countTime == Random.Range(countTime, countTime + 600))
        {
            t = Instantiate(Grass2, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), Grass2.rotation) as Transform;
        }
        if (countTime == Random.Range(countTime, countTime + 500))
        {
            t = Instantiate(Grass3, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), Grass3.rotation) as Transform;
        }
        if (countTime == Random.Range(countTime, countTime + 400))
        {
            t = Instantiate(Grass4, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), Grass4.rotation) as Transform;
        }
        if (countTime == Random.Range(countTime, countTime + 400))
        {
            t = Instantiate(Grass5, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), Grass5.rotation) as Transform;
        }
        //thưởng
        if (countTime == 1000)
        {
            //countLevel += 1;
        }
        if (countTime % 1500 == 0)
        {
            t = Instantiate(coin5, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin5.rotation) as Transform;
        }
        if (countTime % 900 == 0)
        {
            t = Instantiate(coin3, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin3.rotation) as Transform;
        }
        if (countTime % 600 == 0)
        {
            t = Instantiate(coin1, new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin1.rotation) as Transform;
        }
        //trap
        if (countSuperItem != 0)
        {
            countSuperItem++;
        }
        //Khiên đang đếm
        if (countSuperItem >= countShield)
        {
            countSuperItem = 0;
        }
        if (countSuperItem == 0)
        {
            if (countTime % (400 / countLevel) == 0)
            {
                t = Instantiate(trapMilkTea, new Vector3(Random.Range(-6.2f, 6.2f), gamePlayer.transform.position.y + 15, 0), trapMilkTea.rotation) as Transform;
            }
            if (countTime % 2000 == 0)
            {
                t = Instantiate(trapIce, new Vector3(Random.Range(-7f, 6.5f), gamePlayer.transform.position.y + 15, 0), trapIce.rotation) as Transform;
            }
        }
    }

    public void SetCountSuperItem()
    {
        this.countSuperItem = 1;
    }
}
