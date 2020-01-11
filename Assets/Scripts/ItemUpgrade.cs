using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemUpgrade : MonoBehaviour
{
    public string ItemName;
    public string mainMenuScene;

    public Sprite ItemSprite;
    public int Level = 1;
    public int UpToLv2Price;
    public int UpToLv3Price;
    public int UpToLv4Price;
    public int UpToLv5Price;
    public List<int> listSupperItem;

    private LevelBar levelBar;
    private Button upgradeButton;
    private Text upgradePriceText;
    public Text coin;

    private void disableUpgrade()
    {
        upgradeButton.onClick.RemoveAllListeners();
    }

    private void setUpgradePrice(int newLevel)
    {
        int newPrice = 0;
        switch (newLevel)
        {
            case 5:
                upgradePriceText.text = "MAX LEVEL";
                return;
            case 4:
                newPrice = UpToLv5Price;
                break;
            case 3:
                newPrice = UpToLv4Price;
                break;
            case 2:
                newPrice = UpToLv3Price;
                break;
            case 1:
                newPrice = UpToLv2Price;
                break;
            default:
                break;
        }
        upgradePriceText.text = "$" + newPrice;
    }

    private void charge(int newLevel)
    {
        switch (newLevel)
        {
            case 5:
                listSupperItem[1] = listSupperItem[1] - UpToLv5Price;
                break;
            case 4:

                listSupperItem[1] = listSupperItem[1] - UpToLv4Price;
                break;
            case 3:

                listSupperItem[1] = listSupperItem[1] - UpToLv3Price;
                break;
            case 2:

                listSupperItem[1] = listSupperItem[1] - UpToLv2Price;
                break;
            default:
                break;
        }
        if (ItemName == "Jetpack")
        {
            listSupperItem[0] = listSupperItem[0] + 300;
        }
        else if (ItemName == "Double")
        {
            listSupperItem[2] = listSupperItem[2] + 300;
        }
        writeToFileSupper("Assets//Scripts//SupperItem.txt", listSupperItem);
        coin.text = "$" + listSupperItem[1];
    }


    private void updateLevelBar(int newLevel)
    {
        levelBar.SetLevel(newLevel);
    }

    private void onUpgrade()
    {
        listSupperItem = loadFromFileSupper("Assets//Scripts//SupperItem.txt");
        Debug.Log($"level: {Level}, price: {listSupperItem[1]}");
        if (Level == 2 && listSupperItem[1] < UpToLv3Price)
        {
            return;
        }
        if (Level == 3 && listSupperItem[1] < UpToLv4Price)
        {
            return;
        }
        if (Level == 4 && listSupperItem[1] < UpToLv5Price)
        {
            return;
        }
        if (Level == 1 && listSupperItem[1] < UpToLv2Price)
        {
            return;
        }

        Level++;

        if (Level >= 5)
        {
            disableUpgrade();
        }

        setUpgradePrice(Level);
        charge(Level);
        updateLevelBar(Level);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ghi diem
        //0: khieen
        //1: toon tien
        listSupperItem = loadFromFileSupper("Assets//Scripts//SupperItem.txt");
        coin.text = "$" + listSupperItem[1];

        if (ItemName == "Double")
        {
            if (listSupperItem[2] == 1000)
            {
                Level = 1;
            }
            else
        if (listSupperItem[2] == 1300)
            {
                Level = 2;
            }
            else
        if (listSupperItem[2] == 1600)
            {
                Level = 3;
            }
            else
        if (listSupperItem[2] == 1900)
            {
                Level = 4;
            }
            else
        if (listSupperItem[2] == 2200)
            {
                Level = 5;
            }

        }
        else if (ItemName == "Jetpack")
        {
            if (listSupperItem[0] == 1000)
            {
                Level = 1;
            }
            else
        if (listSupperItem[0] == 1300)
            {
                Level = 2;
            }
            else
        if (listSupperItem[0] == 1600)
            {
                Level = 3;
            }
            else
        if (listSupperItem[0] == 1900)
            {
                Level = 4;
            }
            else
        if (listSupperItem[0] == 2200)
            {
                Level = 5;
            }

        }

        Image icon = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Image>();
        icon.sprite = ItemSprite;

        Text name = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Text>();
        name.text = ItemName;

        levelBar = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetComponent<LevelBar>();
        levelBar.SetLevel(Level);

        upgradeButton = this.gameObject.transform.GetChild(1).gameObject.transform.GetComponent<Button>();
        if (Level < 5)
        {
            upgradeButton.onClick.AddListener(onUpgrade);
        }

        upgradePriceText = upgradeButton.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Text>();
        setUpgradePrice(Level);
    }
    private List<int> loadFromFileSupper(string filename)
    {
        var result = new List<int>();
        var lines = File.ReadAllLines(filename);

        if (lines.Length > 0)
        {
            for (int i = 0; i < lines.Length; i += 1)
            {
                result.Add(Int32.Parse(lines[i]));
            }
        }

        return result;
    }
    private void writeToFileSupper(string filename, List<int> scoreBoard)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
        {
            foreach (int user in scoreBoard)
            {
                file.WriteLine(user);
            }
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

}
