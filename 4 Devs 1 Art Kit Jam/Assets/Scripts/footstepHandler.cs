using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepHandler : MonoBehaviour
{

    [SerializeField] private AudioSource footstepAudio;

    public void PlayFootstepSound()
    {
        footstepAudio.pitch = Random.Range(0.85f, 1.15f);
        footstepAudio.Play();
    }
}
