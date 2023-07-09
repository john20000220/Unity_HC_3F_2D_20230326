using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : DamageSystem
{
	private DataHealthEnemy dataEnemy;

	private void Start()
	{
		dataEnemy = (DataHealthEnemy)data;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("ชZพน")) 
		{
			float attack = collision.gameObject.GetComponent<Weapon>().attack;
			GetDamage(attack);
		}

		AudioClip sound = SoundManager.instance.enemyDamaged;

		SoundManager.instance.PlaySound(sound, 0.7f, 2);
	}
	protected override void Dead()
	{
		Destroy(gameObject);
		DropExp();

		AudioClip sound = SoundManager.instance.enemyDead;

		SoundManager.instance.PlaySound(sound, 0.7f, 2);
	}
	private void DropExp()
	{
		if (Random.value <= dataEnemy.dropProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
