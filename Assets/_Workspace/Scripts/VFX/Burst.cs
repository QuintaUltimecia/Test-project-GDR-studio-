using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Burst : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        _player.OnDeath += delegate ()
        {
            PlayEffect();
        };
    }

    private void OnDisable()
    {
        _player.OnDeath -= delegate ()
        {
            PlayEffect();
        };
    }

    private void PlayEffect()
    {
        _particleSystem.Play();
    }
}
