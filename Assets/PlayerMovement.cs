using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator rbani;
    private Collider2D col;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask diePlace;
    [SerializeField]private float defaultSpeed = 1.0f;
    [SerializeField] private float jumpF = 1.0f;
    private float x_move,y_move;
    private enum Player_action {ide,run,jumb,fall};
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>();
        rbani = rb.GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {

            x_move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_move * defaultSpeed, rb.velocity.y);
        //float y_move = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);
        }
        PlayerAnimation();
    }
    private void PlayerAnimation()
    {
        Player_action state = Player_action.ide;
        if (x_move > 0f)
        {
            //sang phai
            state = Player_action.run;
            rbSprite.flipX = false;
        }
        else if (x_move < 0f)
        {
            state = Player_action.run;
            //sang trai
            rbSprite.flipX = true;
        }
         if (rb.velocity.y > .1f)
        {
            state = Player_action.jumb;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = Player_action.fall;
        }
        rbani.SetInteger("Player_action", (int)state);
    }
    private bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size,0f,Vector2.down,.1f,layerMask);
            }
}
