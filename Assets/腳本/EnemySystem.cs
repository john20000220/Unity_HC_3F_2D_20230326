using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("�l�ܳt��"), Range(0, 100)]
    public float moveSpeed = 3.5f;
    [Header("�ĤH���")]
    public DataHealthEnemy data;

    public Transform player;
    private DamagePlayer damagePlayer;
    private float timer;

	private void OnDrawGizmos()
	{
        Gizmos.color = new Color(1, 0.3f, 0.2f, 0.5f);
        Gizmos.DrawSphere(transform.position, data.attackRange);
	}

	private void Awake()
    {
        player = GameObject.Find("�v�ܩi").transform;
        damagePlayer = player.GetComponent<DamagePlayer>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        Attack();

        float distance = Vector3.Distance(transform.position, player.position);
        //print($"<color=#ff9966>�Z���G{distance}</color>");
        if (distance < data.attackRange) Attack();

        if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
        if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 100, 0);
    }

    private void Attack() 
    {
        timer += Time.deltaTime;
        //print($"<color=#99ff66>�p�ɾ��G{timer}</color>");

        if (timer > data.attackSpeed) 
        {
            print("<color=#9966ff>�������a�I</color>");
            damagePlayer.GetDamage(data.attack);
            timer = 0;
        }
    }
}
