using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator animator;

    public float speed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;
    private bool facingRight = true;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Animacion de caminar
        float speedAnimation = Mathf.Abs(move);
        animator.SetFloat("Speed", speedAnimation);

        // Movimiento
        rd.linearVelocity = new Vector2(move * speed, rd.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJump", true);
        }

        // Girar personaje
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}