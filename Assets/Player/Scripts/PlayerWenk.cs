using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWenk : MonoBehaviour
{
    public Collider2D wenkCollider;
    public ContactFilter2D wenkMask;

    Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Wenk"))
        {
            Wenk();
        }
    }

    void Wenk()
    {
        Collider2D[] collisions = new Collider2D[10];
        int n = wenkCollider.OverlapCollider(wenkMask, collisions);

        for (int i = 0; i < n; i++)
        {
            if (collisions[i].TryGetComponent(out HumanBehaviour human))
            {
                Debug.Log("WENK");
                StartCoroutine(HumanBehaviour.Instance.Wenk());
            }
        }

        animator.SetTrigger("isWenk");
        AudioManager.Instance.PlaySFX("wenk");
    }
}
