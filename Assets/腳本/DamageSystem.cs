using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;

    [Header("�e���ˮ`��")]
    public GameObject prefabDamage;

    protected float hp;
    protected float hpMax;

    private void Awake()
    {
        hp = data.hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("�Z��"))
        {
            float attack = collision.gameObject.GetComponent<Weapon>().attack;
            GetDamage(attack);
        }
    }

    public virtual void GetDamage(float damage)
    {
        print($"<color=#ff6699>���쪺�ˮ`{damage}</color>");
        hp -= damage;
        GameObject tempDamage = Instantiate(prefabDamage, transform.position, Quaternion.identity);
        tempDamage.transform.Find("��r�ˮ`��").GetComponent<TextMeshProUGUI>().text = damage.ToString();
        Destroy(tempDamage, 1.5f);
        if (hp <= 0) Dead();
    }

    protected virtual void Dead()
    {

    }

}
