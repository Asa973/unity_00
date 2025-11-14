using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 8f;
    public float jumpForce = 5f;

    private int groundContacts = 0;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 force = input.normalized * moveSpeed;
        rb.AddForce(force, ForceMode.Acceleration);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        groundContacts++;
        isGrounded = groundContacts > 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        groundContacts--;
        isGrounded = groundContacts > 0;
    }
}
