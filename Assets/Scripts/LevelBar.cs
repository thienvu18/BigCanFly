using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite EmptyLevel;
    public Sprite FullLevel;

    public void SetLevel(int level)
    {
        if (level < 0 || level > 5) return;
        int i = 0;
        for (; i < level; i++)
        {
            Image lv = this.gameObject.transform.GetChild(i).gameObject.transform.GetComponent<Image>();
            lv.sprite = FullLevel;
        }
        for (; i < 5; i++)
        {
            Image lv = this.gameObject.transform.GetChild(i).gameObject.transform.GetComponent<Image>();
            lv.sprite = EmptyLevel;
        }
    }
}
