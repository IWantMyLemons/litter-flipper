using UnityEngine;

public class FishMoved : MonoBehaviour
{
    public float speed = 6f;
    public Transform shorePosition;
    public float tolerance = 0.01f; // adjust this value as needed

    private bool hasReachedShore = false;
    private Animator animator; // initialize animator here

    void Awake()
    {
        animator = GetComponent<Animator>(); // ensure animator is not null
    }

    void Update()
    {
        // Debug.Log("Update method called");
        if (!hasReachedShore)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.right * step);

            if (Mathf.Abs(transform.position.x - shorePosition.position.x) < tolerance)
            {
                hasReachedShore = true;
                animator.SetBool("IsOnShore", true);
                animator.transform.Rotate(0, 180, 0);
            }
        }
    }
}