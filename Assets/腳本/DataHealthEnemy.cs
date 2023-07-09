using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AFa/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
    [Header("�����g��Ȫ���")]
    public GameObject prefabExp;
    [Header("�����g��Ⱦ��v"), Range(0, 1)]
    public float dropProbability;
    [Header("�����O"), Range(0, 1000)]
    public float attack = 20;
    [Header("�����t��"), Range(0, 5)]
    public float attackSpeed = 2.5f;
    [Header("�����Z��"), Range(0, 10)]
    public float attackRange = 3;
}
