using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("�ͦ����j"), Range(0, 10)]
    public float interval = 3.5f;
    [Header("�Z���w�s��")]
    public GameObject prefabWeapon;
    [Header("�Z���ͦ���m")]
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
