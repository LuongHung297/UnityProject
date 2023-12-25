using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;
    private Rigidbody2D rb;

    private Animator ani;

    public void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            ani.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void TpBack()
    {
        rb.transform.position = spawnpoint.position;
        ani.ResetTrigger("death");
        ani.SetTrigger("alive");
        ani.SetInteger("Player_action",0);

    }
    private void startGame()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        ani.ResetTrigger("alive");

    }
}
