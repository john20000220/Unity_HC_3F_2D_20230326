using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("����")]
    public Rigidbody2D rig;
    [Header("�Z���o�g�O�D")]
    public Vector2 power;

    private void Awake()
    {
        rig.AddForce(power);
    }
}
