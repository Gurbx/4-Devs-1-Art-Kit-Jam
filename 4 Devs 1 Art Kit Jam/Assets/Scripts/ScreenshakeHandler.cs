using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ScreenshakeHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    private static CinemachineBasicMultiChannelPerlin noise;

    private static float timer = 0;

    void Start()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            noise.m_AmplitudeGain = 0;
            noise.m_FrequencyGain = 0;
        }

    }

    public static void AddScreenShake(float amplitude, float frequency, float duration)
    {
        //Prevents small shakes from overriding big ones
        if (amplitude < noise.m_AmplitudeGain || frequency < noise.m_FrequencyGain) return;

        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        timer = duration;
    }
}
