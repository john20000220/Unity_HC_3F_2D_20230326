using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [Header("����")]
    public Rigidbody2D rig;
    [Header("�Z���o�g�O�D")]
    public Vector2 power;
    [Header("�Z�������O")]
    public float attack = 50;

    private void Awake()
    {
        rig.AddForce(power);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
