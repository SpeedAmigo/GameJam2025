using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class ScreenLight : MonoBehaviour
{
    private Light2D _light;
    private float _noiseOffset;
    
    [Range(0f, 1f)]
    [SerializeField] private float flickerTime;
    [SerializeField] private List<Color> colors = new();
    [SerializeField] private SpriteRenderer screenSprite;

    private IEnumerator LightWave()
    {
        float time = 0;

        while (true)
        {
            time += Time.deltaTime * flickerTime;
            
            float noise = Mathf.PerlinNoise(time * _noiseOffset, 0f);
            _light.falloffIntensity = Mathf.Lerp(0.6f, 0.7f, noise);
            
            yield return null;
        }
    }
    
    private IEnumerator LightColor()
    {
        while (true)
        {
            if (colors.Count == 0) yield break;

            int colorIndex = Random.Range(0, colors.Count);
            Color nextColor = colors[colorIndex];
            Color startColor = _light.color;

            float elapsedTime = 0f;
            float duration = 2f; // Adjust this for smoothness

            while (elapsedTime < duration)
            {
                _light.color = Color.Lerp(startColor, nextColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _light.color = nextColor;
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void Start()
    {
        _light = GetComponent<Light2D>();
        _noiseOffset = Random.Range(0f, 100f);
        StartCoroutine(LightWave());
        StartCoroutine(LightColor());
    }

    private void Update()
    {
        screenSprite.color = _light.color;
    }
}
