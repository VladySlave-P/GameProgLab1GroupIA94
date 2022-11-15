using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public float jumpPower = 20f;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");// -1 to 1
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
