using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("生成間隔"), Range(0, 10)]
    public float interval = 3.5f;
    [Header("武器預製物")]
    public GameObject prefabWeapon;
    [Header("武器生成位置")]
    public Transform pointWeapon;

    public bool onHit = false;

    private void SpawnWeapon()
    {
        Instantiate(prefabWeapon, pointWeapon.position, pointWeapon.rotation);
    }

    private void Awake()
    {
        InvokeRepeating("SpawnWeapon", 0, interval);
    }
   
}
