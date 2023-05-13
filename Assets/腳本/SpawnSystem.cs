using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("�ͦ����j")]
    public float interval = 3.5f;

    [Header("�Ǫ��w�s��")]
    public GameObject prefabEnemy;

    private void SpawnEnemy()
    {
        Instantiate(prefabEnemy, transform.position, transform.rotation);
    }

    private void Awake()
    {
        InvokeRepeating("SpawnEnemy", 0, interval);
    }
}
