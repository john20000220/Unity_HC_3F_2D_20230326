using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip levelUp;
    public AudioClip btnNormal;
    public AudioClip btnLevelupSkill;
    public AudioClip enemyDamaged;
    public AudioClip enemyDead;
    public AudioClip playerDamaged;
    public AudioClip playerDead;
    public AudioClip weaponFired;

    private AudioSource aud;

    public static SoundManager instance;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound, float min, float max) 
    {
        float volume = Random.Range(min, max);
        aud.PlayOneShot(sound, volume);
    }
}
