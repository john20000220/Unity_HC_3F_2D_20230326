using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("�Z��"))
        {
            print("�Q�Z������");
        }
    }
}
