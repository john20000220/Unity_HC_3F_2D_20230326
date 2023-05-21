using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("°lÂÜ³t«×"), Range(0, 100)]
    public float moveSpeed = 3.5f;

    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("¥vµÜ©i").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
