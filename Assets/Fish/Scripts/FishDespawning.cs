using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDespawning : MonoBehaviour
{
    [Tooltip("Time for fish to despawn in seconds")]
    public float lifetime;
    [Tooltip("Percent where fish should blink")]
    [Range(0, 1)]
    public float blinkingPercentage;
    [Tooltip("Speed to blink at (coefficient of time)")]
    public float blinkingSpeed;
    [Tooltip("Acceleration to blink at (exponent of time)")]
    public float blinkingAccel;
    [Tooltip("Color to blink when below Blinking Percentage")]
    public Color blinkingColor;


    float age = 0;
    new SpriteRenderer renderer;

    void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (age > lifetime) // run out of time
        {
            renderer.color = new Color(0.0f, 0.3f, 0.15f);
            return;
        }
        age += Time.deltaTime;
        if (age > blinkingPercentage * lifetime)
        {
            renderer.color = Color.Lerp(
                Color.white,
                blinkingColor,
                MathF.Pow(MathF.Sin(Mathf.Pow(age - blinkingPercentage * lifetime, blinkingAccel) * MathF.PI * blinkingSpeed), 2)
            );
        }
    }
}
