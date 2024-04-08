using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
    [Header("���")]
    public Text imgHp;
    [Header("����t��")]
    public ControlSystem controlSystem;
    //[Header("�����e��")]
    //public GameObject gameOver;
    public int attackTime;
    public Text getDamaged;

    private void Update()
    {
        imgHp.text = "���a��q�G" + data.hp.ToString();
        getDamaged.text = "�Q�������ơG" + attackTime.ToString();
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        attackTime++;

        AudioClip sound = SoundManager.instance.playerDamaged;

        SoundManager.instance.PlaySound(sound, 0.7f, 2);
    }

    protected override void Dead()
    {
        controlSystem.enabled = false;

        //gameOver.SetActive(true);

        AudioClip sound = SoundManager.instance.playerDead;

        SoundManager.instance.PlaySound(sound, 0.7f, 2);
    }
}
