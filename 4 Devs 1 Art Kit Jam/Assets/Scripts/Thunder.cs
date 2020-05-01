using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Thunder : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Color lightingColor;
    [SerializeField] private AudioSource thunderSound;

    [SerializeField] private float intervalTime = 5f;

    private Color orgLightColor;
    private Color orgCamBGColor;
    private float orgIntensity;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        orgLightColor = globalLight.color;
        orgIntensity = globalLight.intensity;
        orgCamBGColor = camera.backgroundColor;

        timer = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LightningStrike();
            timer = intervalTime + Random.Range(-intervalTime*0.3f, intervalTime*0.3f);
        }

        if (globalLight.intensity > orgIntensity)
        {
            globalLight.intensity -= Time.deltaTime * 2.5f;
            camera.backgroundColor = Color.Lerp(camera.backgroundColor, orgCamBGColor, Mathf.PingPong(Time.time, 0.2f));
        }
        else
        {
            ResetLights();
        }
    }

    private void LightningStrike()
    {
        ScreenshakeHandler.AddScreenShake(5, 5, 0.5f);

        thunderSound.pitch = Random.Range(0.5f, 1f);
        thunderSound.Play();

        globalLight.color = lightingColor;
        camera.backgroundColor = lightingColor;
        globalLight.intensity = 1.25f;
        //Invoke("MiniStrike", 0.05f);
        Invoke("MiniStrike", 0.15f);
      //  Invoke("ResetLights", 2.25f);
    }

    private void MiniStrike()
    {
        globalLight.color = lightingColor;
     //   camera.backgroundColor = lightingColor;
        globalLight.intensity = 1f;
    }

    private void ResetLights()
    {
        globalLight.color = orgLightColor;
        camera.backgroundColor = orgCamBGColor;
        globalLight.intensity = orgIntensity;
    }
}
