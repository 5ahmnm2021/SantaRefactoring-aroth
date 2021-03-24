using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float jumpForce;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver && !gameOver && !gameOver)
        {
            if (grounded == true)
            {
                Jump();
            }
        }
    }

    private bool grounded;
    private bool gameOver;

    private void Jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger("Jump");

        GameManager.instance.IncrementScore();
        Debug.Log("DeleteMe");
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle"){
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play("SantaDeath");
            gameOver = SetGameOverTrue();
        }
    }




}
