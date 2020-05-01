using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void PlayParticleSystem()
    {
        particles.Play();
    }
}
