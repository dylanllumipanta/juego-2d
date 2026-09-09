using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rd;

    public float speed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        rd.linearVelocity = new Vector2(move * speed, rd.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}