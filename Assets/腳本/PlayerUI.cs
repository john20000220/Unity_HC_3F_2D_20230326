using UnityEngine;

public class PlayerUI : MonoBehaviour
{
	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("�v�ܩi").transform;
	}
	// Update is called once per frame
	void Update()
    {
		transform.position = player.position;
    }
}
