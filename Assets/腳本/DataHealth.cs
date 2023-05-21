using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AFa/Data Health")]
public class DataHealth : ScriptableObject
{
    [Header("¦å¶q"), Range(1, 5000)]
    public float hp = 500;
}
