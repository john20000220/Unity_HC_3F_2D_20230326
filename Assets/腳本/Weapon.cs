using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("剛體")]
    public Rigidbody2D rig;
    [Header("武器發射力道")]
    public Vector2 power;
    [Header("武器攻擊力")]
    public float attack = 50;

    private void Awake()
    {
        rig.AddForce(power);
    }
}
