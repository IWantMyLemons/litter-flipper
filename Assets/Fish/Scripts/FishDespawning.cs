using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
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

    public bool is_alive = true;
    float age = 0;
    new SpriteRenderer renderer;
    Animator animator;

    void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_alive) return;

        if (age > lifetime) // run out of time
        {
            Die();
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

    private void Die()
    {
        renderer.color = Color.white;
        is_alive = false;
        animator.SetBool("is_alive", false);
        TrashItem trash = gameObject.AddComponent<TrashItem>();
        trash.trashCategories = new string[1];
        trash.trashCategories[0] = "trash";
    }
}
