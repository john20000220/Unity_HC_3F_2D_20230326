using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;

    private float hp;

    private DataHealthEnemy dataEnemy;

    private void Awake()
    {
        hp = data.hp;
        dataEnemy = (DataHealthEnemy)data;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("�Z��"))
        {
            //print("�Q�Z������");
            GetDamage();
        }
    }

    private void GetDamage()
    {
        hp -= 50;
        print("��q�ѤU �G" + hp);

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        Destroy(gameObject);
        DropExp();
    }

    private void DropExp()
    {
        if(Random.value <= dataEnemy.dropProbability)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}
