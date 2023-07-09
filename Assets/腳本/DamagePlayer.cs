using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
    [Header("���")]
    public Image imgHp;
    [Header("����t��")]
    public ControlSystem controlSystem;
    [Header("�����e��")]
    public GameObject gameOver;

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        imgHp.fillAmount = hp / hpMax;

        AudioClip sound = SoundManager.instance.playerDamaged;

        SoundManager.instance.PlaySound(sound, 0.7f, 2);
    }

    protected override void Dead()
    {
        controlSystem.enabled = false;

        gameOver.SetActive(true);

        AudioClip sound = SoundManager.instance.playerDead;

        SoundManager.instance.PlaySound(sound, 0.7f, 2);
    }
}
