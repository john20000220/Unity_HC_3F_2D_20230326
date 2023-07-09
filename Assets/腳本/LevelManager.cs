using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;


public class LevelManager : MonoBehaviour
{

    [Header("���ŻP�g��Ȥ���")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;

    [Header("���ŤW��"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;
    public float[] expNeeds = { 100, 200, 300 };

	#region �ɯŨt��
	[Header("�ɯŭ��O")]
	public GameObject goLevelUp;

	[Header("�ޯ����϶� 1 ~ 3")]
	public GameObject[] goChooseSkills;

	[Header("�����ޯ�")]
	public DataSkill[] dataskills;

	[Header("���a����G�v�ܩi")]
	public ControlSystem controlSystem;

	[Header("���a��q�G�v�ܩi")]
	public DataHealth dataHealth;

	[Header("���a�Z���G�v�ܩi")]
	public WeaponSystem weaponSystem;

	[Header("�g�窫��G�����g���")]
	public CircleCollider2D expBanana;

	[Header("�Z���G�e����")]
	public Weapon weaponBee1;

	[Header("�Z���G�e���k")]
	public Weapon weaponBee2;

	[Header("�Z���G�e���W")]
	public Weapon weaponBee3;

	[Header("�Z���G�e���U")]
	public Weapon weaponBee4;

	public List<DataSkill> randomSkill = new List<DataSkill>();

	private void Awake()
	{
		controlSystem.moveSpeed = dataskills[3].skillValues[0];
		weaponBee1.attack = dataskills[0].skillValues[0];
		weaponBee2.attack = dataskills[0].skillValues[0];
		weaponBee3.attack = dataskills[0].skillValues[0];
		weaponBee4.attack = dataskills[0].skillValues[0];
		weaponSystem.interval = dataskills[2].skillValues[0];
		dataHealth.hp = dataskills[2].skillValues[0];
		expBanana.radius = dataskills[4].skillValues[0];
	}

	[ContextMenu("��s�g��ȻݨD��")]
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
		print($"<color=yellow>��e�g��ȡG{ exp }</color>");

		if (exp >= expNeeds[lv - 1] && lv < lvMax)
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
		Time.timeScale = 0;

		goLevelUp.SetActive(true);

		randomSkill = dataskills.Where(x => x.lv < 5).ToList();
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();
		for (int i = 0; i < 3; i++)
		{
			goChooseSkills[i].transform.Find("�ޯ�W��").GetComponent<Text>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("�ޯ൥��").GetComponent<Text>().text = "����Lv " + randomSkill[i].lv;
			goChooseSkills[i].transform.Find("�ޯ�ϥ�").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
			goChooseSkills[i].transform.Find("�ޯ�y�z").GetComponent<Text>().text = randomSkill[i].description;
		}
	}

	public void ClickSkillButton(int number)
	{
		print("���a���U���ޯ�O " + randomSkill[number].nameSkill);

		randomSkill[number].lv++;

		if (randomSkill[number].nameSkill == "�H�G�j��") UpgradePlayerHealth(number);
		if (randomSkill[number].nameSkill == "�W�Że��") UpgradeAttackDamage(number);
		if (randomSkill[number].nameSkill == "����v�ܩi") UpgradeAttackSpeed(number);
		if (randomSkill[number].nameSkill == "�U�Ϥ�") UpgradeMagnet(number);
		if (randomSkill[number].nameSkill == "�j�O��ƲG") UpgradeMoveSpeed(number);

		Time.timeScale = 1;
		goLevelUp.SetActive(false);
	}

	private void UpgradePlayerHealth(int number)
	{
		int lv = randomSkill[number].lv;
		dataHealth.hp += randomSkill[number].skillValues[lv - 1];
	}

	private void UpgradeAttackDamage(int number)
	{
		int lv = randomSkill[number].lv;
		weaponBee1.attack = randomSkill[number].skillValues[lv - 1];
		weaponBee2.attack = randomSkill[number].skillValues[lv - 1];
		weaponBee3.attack = randomSkill[number].skillValues[lv - 1];
		weaponBee4.attack = randomSkill[number].skillValues[lv - 1];
	}

	private void UpgradeAttackSpeed(int number)
	{
		int lv = randomSkill[number].lv;
		weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
	}

	private void UpgradeMagnet(int number)
	{
		int lv = randomSkill[number].lv;
		expBanana.radius = randomSkill[number].skillValues[lv - 1];
	}

	private void UpgradeMoveSpeed(int number) 
	{
        int lv = randomSkill[number].lv;
        controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
    }
	#endregion
}

