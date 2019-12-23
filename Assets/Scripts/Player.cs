using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float xVelocity;

    public bool IsOnGround;
    public float Speed;
    public float CheckRadius;
    public LayerMask Platform;
    public GameObject GroundCheck;

    bool isPlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsOnGround = Physics2D.OverlapCircle(GroundCheck.transform.position, CheckRadius, Platform);
        anim.SetBool("IsOnGround",IsOnGround);
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * Speed, rb.velocity.y);
        anim.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fun"))
        {
            rb.velocity = new Vector2(rb.velocity.x,10f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            anim.SetTrigger("dead");
        }
    }
    public void PlayerDaad()
    {
        isPlayerDead = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GroundCheck.transform.position,CheckRadius);
    }
}
