using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;

public class MapLoad : MonoBehaviour
{
    public Transform[] coin = new Transform[3];//-7.5f->7.5f
    public Transform[] trapIce = new Transform[3];//-7f->6.5f
    //mapload
    public Transform[] Grass = new Transform[5];//5.5f->-5.5f
    //supper item
    public Transform[] supperItem= new Transform[3];//5.5f->-5.5f

    //trap
    public Transform trapMilkTea;//-6.2f->6.2f
    public Transform trapPizza;//-6.2f->6.2f
    public GameObject boom;//-6.2f->6.2f

    public PlayerController gamePlayer;
    private int countTime = 0;
    private int countLevel = 1;
    public int countSuperItem = 0;
    public int countCoinx2 = 0;
    //biến đếm thời gian có hiệu lực của khiên
    private int countShield;

    // Start is called before the first frame update
    void Start()
    {
        //line[0]: khiên
        string[] lines = File.ReadAllLines("Assets//Scripts//SupperItem.txt");
        countShield = int.Parse(lines[0]);
        //Transform t = null;
        //t = Instantiate(Grass2, new Vector3(6f, gamePlayer.transform.position.y + 5, 0), Grass2.rotation) as Transform;
        //t = Instantiate(Grass2, new Vector3(-6f, gamePlayer.transform.position.y + 5, 0), Grass2.rotation) as Transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlayer.live >= 1)
        {
            Debug.Log("count conin " + countCoinx2);
            countTime++;
            Transform t = null;
            GameObject m = null;
            //supper item
            if (countTime %2000==0)
            {
                t = Instantiate(supperItem[1], new Vector3(Random.Range(-5.5f, 5.5f), gamePlayer.transform.position.y + 15, 0), supperItem[1].rotation) as Transform;
            }
            if (countTime % 2500 == 0)
            {
                t = Instantiate(supperItem[2], new Vector3(Random.Range(-5.5f, 5.5f), gamePlayer.transform.position.y + 15, 0), supperItem[2].rotation) as Transform;
            }
            if (countTime % 3000 == 0)
            {
                t = Instantiate(supperItem[0], new Vector3(Random.Range(-5.5f, 5.5f), gamePlayer.transform.position.y + 15, 0), supperItem[0].rotation) as Transform;
            }
            //mapload cây cỏ
            if (countTime == Random.Range(countTime, countTime + 700))
            {
                t = Instantiate(Grass[0], new Vector3(Random.Range(-5.5f, 5.5f), gamePlayer.transform.position.y + 15, 0), Grass[0].rotation) as Transform;
            }
            if (countTime == Random.Range(countTime, countTime + 600))
            {
                t = Instantiate(Grass[1], new Vector3(Random.Range(-6f, 6f), gamePlayer.transform.position.y + 15, 0), Grass[1].rotation) as Transform;
            }
            if (countTime == Random.Range(countTime, countTime + 500))
            {
                t = Instantiate(Grass[2], new Vector3(Random.Range(-6f, 6f), gamePlayer.transform.position.y + 15, 0), Grass[2].rotation) as Transform;
            }
            if (countTime == Random.Range(countTime, countTime + 400))
            {
                t = Instantiate(Grass[3], new Vector3(Random.Range(-6f, 6f), gamePlayer.transform.position.y + 15, 0), Grass[3].rotation) as Transform;
            }
            if (countTime == Random.Range(countTime, countTime + 400))
            {
                t = Instantiate(Grass[4], new Vector3(Random.Range(-6f, 6f), gamePlayer.transform.position.y + 15, 0), Grass[4].rotation) as Transform;
            }
            //thưởng
            if (countTime == 1000)
            {
                countLevel += 1;//nâng độ khó ở đây(nâng level)
            }
            if (countTime % 1500 == 0)
            {
                t = Instantiate(coin[2], new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin[2].rotation) as Transform;
            }
            if (countTime % 900 == 0)
            {
                t = Instantiate(coin[1], new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin[1].rotation) as Transform;
            }
            if (countTime % 600 == 0)
            {
                t = Instantiate(coin[0], new Vector3(Random.Range(-7.5f, 7.5f), gamePlayer.transform.position.y + 15, 0), coin[0].rotation) as Transform;
            }
            //x2
            if (countCoinx2 > 0)
            {
                countCoinx2++;
            }
            if (countCoinx2 >= 2500)
            {
                countCoinx2 = 0;
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
                if (countTime % (600 / countLevel) == 0)
                {
                    t = Instantiate(trapMilkTea, new Vector3(Random.Range(-6.2f, 6.2f), gamePlayer.transform.position.y + 15, 0), trapMilkTea.rotation) as Transform;
                }
                if (countTime % 2000 == 0)
                {
                    t = Instantiate(trapIce[Random.Range(0, 2)], new Vector3(0, gamePlayer.transform.position.y + 15, 0), trapIce[Random.Range(0, 2)].rotation) as Transform;
                }
                if (countTime % 100 == 0)
                {
                    m = Instantiate(boom);
                    //m.transform.position = new Vector3(5.96f, gamePlayer.transform.position.y + 15, 0);
                    m.transform.position = new Vector3(100,100,100);
                    Debug.Log("boooooommmmm" + m.transform.position.y);
                }
            }

        }
    }

    public void SetCountSuperItem()
    {
        this.countSuperItem = 1;
    }
    public void SetCountCoinx2()
    {
        this.countCoinx2 = 1;
        Debug.Log("đã ăn item   " + countCoinx2);
    }
}
