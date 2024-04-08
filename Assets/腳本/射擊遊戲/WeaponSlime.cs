using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSlime : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool isMoveRight;
    public bool isMoveLeft;
    public int bulletNum;
    public Text bulletN;

    private void Start()
    {
        bulletNum = 50;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMoveRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMoveRight = false;
        }
        fireWeapon();
        bulletN.text = "彈藥數量：" + bulletNum.ToString();
    }

    public void fireWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E) && bulletNum > 0)
        {
            GameObject bulletObject = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            BulletControl bullet = bulletObject.GetComponent<BulletControl>();
            bulletNum--;
            if (isMoveRight)
            {
                bullet.isMoveRight = true;
            }
            else
            {
                bullet.isMoveRight = false;
            }
        }
        else if (bulletNum < 0)
        {
            Debug.Log("沒有子彈!");
        }
    }
}
