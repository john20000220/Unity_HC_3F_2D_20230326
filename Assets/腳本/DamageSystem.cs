using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("血量資料")]
    public DataHealth data;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("武器"))
        {
            print("被武器打到");
        }
    }
}
