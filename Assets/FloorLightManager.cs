using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FloorLightManager : MonoBehaviour
{
    [SerializeField] private List<Light2D> floorLights = new();
    [Range(0, 50)]
    [SerializeField] private float lightIntensity;
    [SerializeField] private float transitionSpeed;
    
    [SerializeField] private GameObject cinemaLights;

    private void SetLightsIntensity(float value)
    {
        foreach (Light2D light in floorLights)
        {
            light.intensity = Mathf.Lerp(light.intensity, value, transitionSpeed * Time.deltaTime);

            if (lightIntensity == 0)
            {
                cinemaLights.SetActive(false);
            }
            else
            {
                cinemaLights.SetActive(true);
            }
        }   
    }

    private void Update()
    {
        SetLightsIntensity(lightIntensity);
    }
}
