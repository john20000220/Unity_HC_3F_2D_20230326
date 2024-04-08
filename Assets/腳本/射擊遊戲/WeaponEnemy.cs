using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool isMoveRight;
    public bool isMoveLeft;
    public float timer;

    private void Start()
    {
        timer = 3f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            fireWeapon();
            timer = 3f;
        }
    }

    public void fireWeapon()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }
}
