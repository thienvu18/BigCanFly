using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgrade : MonoBehaviour
{
    public string ItemName;
    public Sprite ItemSprite;
    public int Level = 1;
    public int UpToLv2Price;
    public int UpToLv3Price;
    public int UpToLv4Price;
    public int UpToLv5Price;

    private LevelBar levelBar;
    private Button upgradeButton;
    private Text upgradePriceText;

    private void disableUpgrade()
    {
        upgradeButton.onClick.RemoveAllListeners();
    }

    private void setUpgradePrice(int newLevel)
    {
        int newPrice = UpToLv2Price;

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
            default:
                break;
        }

        upgradePriceText.text = "$" + newPrice;
    }

    private void updateLevelBar(int newLevel)
    {
        levelBar.SetLevel(newLevel);
    }

    private void onUpgrade()
    {
        Level++;

        if (Level >= 5)
        {
            disableUpgrade();
        }

        setUpgradePrice(Level);
        updateLevelBar(Level);
    }

    // Start is called before the first frame update
    void Start()
    {
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
}
