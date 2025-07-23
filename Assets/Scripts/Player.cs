using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float forcaPulo = 5f;
    [SerializeField] private bool noPiso = true;

    private float moveH;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        Pular();
    }

    private void Andar()
    {
        moveH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveH * Time.deltaTime * velocidade, 0, 0);
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            AnimaAndar();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            AnimaAndar();
        }
    }

    private void AnimaAndar()
    {
        if (moveH > 0)
        {
            sprite.flipX = false;
            animator.SetTrigger("Rum");
        }
        else if (moveH < 0)
        {
            sprite.flipX = true;
            animator.SetTrigger("Rum");
        }
        else
        {
            animator.SetTrigger("Rum");
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noPiso)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noPiso = false;
            animator.SetBool("Piso", false);
            animator.SetTrigger("Pulo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            noPiso = true;
        }

        
    }

    
}
