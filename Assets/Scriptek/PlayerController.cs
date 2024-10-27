using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Mozg�s ir�ny�nak lek�rdez�se
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Mozg�si vektor friss�t�se
        movementDirection = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);

        // Karakter ir�ny�nak be�ll�t�sa (balra vagy jobbra n�z�s)
        if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = true; // Jobbra n�z
        }
        else if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = false; // Balra n�z
        }

        // Ugr�s kezel�se, ha a j�t�kos a talajon van
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Ugr�s ut�n leveg�ben van
        }
    }

    void FixedUpdate()
    {
        // Mozg�s alkalmaz�sa
        rb.velocity = new Vector2(movementDirection.x, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha a karakter talajjal �rintkezik, ugr�sra k�szen �ll
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Ha elhagyja a talajt, akkor m�r nincs a f�ld�n
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
