using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikkuminen : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;

    public bool jumping;

    [SerializeField] float sizeX;
    [SerializeField] float sizeY;

    [SerializeField] LayerMask groundLayer;
    Rigidbody2D rb2D;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * speed * Time.deltaTime;
        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        if (!jumping)
        {
            animator.SetFloat("speed", Mathf.Abs(movement.x));
        }

        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(sizeX, sizeY), 0, groundLayer);
        if (hit)
        {
            animator.SetBool("jumping", false);
        }

        if (Input.GetButtonDown("Jump") && hit)
        {
            rb2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            animator.SetBool("jumping", true);
        }
    }
}
