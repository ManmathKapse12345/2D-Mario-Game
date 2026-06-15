// using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public bool isRight=false;
    public float translationSpeed = 10f;
    private Rigidbody2D playerRigidBody2D;
    private float force = 100f;
    // private float force = 150f;
    private bool isGround = true;

    public int health =0 ;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
        playerRigidBody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            Debug.Log("GameOver!");
            SceneManager.LoadScene("SampleScene");
        }
        transform.rotation=Quaternion.Euler(0,0,0);
        horizontalInput=Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && isGround)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
        if((horizontalInput>0 && isRight) || (horizontalInput<0 && !isRight))
        {
            FlipPlayer();
        }
        transform.Translate(Vector3.right*Time.deltaTime*translationSpeed*horizontalInput);
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            // animator.SetBool("isRunning",false);
            // animator.SetBool("isJumping",true);
            playerRigidBody2D.AddForce(Vector3.up*force,ForceMode2D.Impulse);
            isGround=false;
        }
        
    }

    void FlipPlayer()
    {
        isRight=!isRight;
        Vector3 localScalePlayer = transform.localScale;
        localScalePlayer.x=localScalePlayer.x*-1;
        transform.localScale=localScalePlayer;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            health=health+8;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            health=health+10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            // animator.SetBool("isJumping",false);
        }
        if (collision.gameObject.CompareTag("EnemyBlock"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
