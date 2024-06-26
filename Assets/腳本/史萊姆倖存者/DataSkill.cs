using UnityEngine;

[CreateAssetMenu(menuName ="AFa/Data Skill")]
public class DataSkill : ScriptableObject
{
    [Header("技能名稱")]
    public string nameSkill;

    [Header("技能等級")]
    public float[] skillValues;

    [Header("技能圖示")]
    public Sprite iconSkill;

    [Header("技能描述"), TextArea(3, 10)]
    public string description;

    public int lv = 1;

    private void OnDisable()
    {
        lv = 1;
    }
}
