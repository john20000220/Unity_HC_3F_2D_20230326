using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;


public class LevelManager : MonoBehaviour
{
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;

    [Header("等級上限"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;
    public float[] expNeeds = { 100, 200, 300 };

    [Header("升級面板")]
    public GameObject goLevelUp;

    [Header("技能選取區塊 1 ~ 3")]
    public GameObject[] goChooseSkills;

    [Header("全部技能")]
    public DataSkill[] dataskills;

    public List<DataSkill> randomSkill = new List<DataSkill>();


    [ContextMenu("更新經驗值需求表")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[lvMax];

        for (int i = 0; i < lvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>當前經驗值：{ exp }</color>");

        if (exp >= expNeeds[lv - 1])
        {
            exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = $"Lv {lv}";
            LevelUp();
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }

    private void LevelUp()
    {
        goLevelUp.SetActive(true);

        randomSkill = dataskills.Where(x => x.lv < 5).ToList();
        randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();
        for (int i = 0; i < 3; i++)
        {
            goChooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
        }
    }

}

