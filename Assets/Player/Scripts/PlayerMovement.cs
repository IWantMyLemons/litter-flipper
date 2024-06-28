using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast the player moves")]
    public float movementSpeed;

    Rigidbody2D rb;
    Vector2 inputDirection;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        inputDirection.Normalize();
    }

    public void FixedUpdate()
    {
        if (inputDirection.magnitude >= float.Epsilon)
        {
            rb.transform.Translate(Time.fixedDeltaTime * movementSpeed * inputDirection);
        }
    }


}