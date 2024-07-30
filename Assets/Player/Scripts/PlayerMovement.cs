using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast the player moves")]
    public float movementSpeed;

    Rigidbody2D rb;
    Vector2 inputDirection;
    Animator animator;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        inputDirection.Normalize();
    }

    public void FixedUpdate()
    {
        if (inputDirection.magnitude >= 1e-3)
        {
            transform.localScale = new Vector3(inputDirection.x > 0 ? 1.0f : -1.0f, 1.0f, 1.0f);
            animator.SetBool("isSliding", true);
            rb.transform.Translate(Time.fixedDeltaTime * movementSpeed * inputDirection);
        }
        else
        {
            animator.SetBool("isSliding", false);
        }
    }


}