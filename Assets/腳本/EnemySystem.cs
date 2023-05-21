using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("�l�ܳt��"), Range(0, 100)]
    public float moveSpeed = 3.5f;

    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("�v�ܩi").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
