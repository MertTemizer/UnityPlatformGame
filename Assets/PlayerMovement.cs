using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public bool faceRight = true;
    Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            animator.SetTrigger("ZıplamaAnimasyonu");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }

        if(movement > 0 && faceRight == false)
        {
            turn();
        }

        if(movement < 0 && faceRight == true)
        {
            turn();
        }


        if(movement != 0)
        {
            animator.SetBool("KosmaAnimasyonu", true);
        }
        else
        {
            animator.SetBool("KosmaAnimasyonu", false);
        }

    }

    void turn()
    {
        faceRight = !faceRight;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;

    }

}


