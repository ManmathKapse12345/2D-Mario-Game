// using System.Numerics;
using NUnit.Framework;
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
    private float platformForce=180f;

    public int health =0 ;
    private Animator animator;
    public bool isOnPlatform=false;
    public bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
        playerRigidBody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -25f)
        {
            Debug.Log("GameOver!");
            SceneManager.LoadScene("Level3");
        }
        transform.rotation=Quaternion.Euler(0,0,0);
        horizontalInput=Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && isGround && !isGameOver)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
        if((horizontalInput>0 && isRight && !isGameOver) || (horizontalInput<0 && !isRight && !isGameOver))
        {
            FlipPlayer();
        }
        if (!isGameOver)
        {
            transform.Translate(Vector3.right*Time.deltaTime*translationSpeed*horizontalInput);
        }
        if (Input.GetKey(KeyCode.Space) && isGround && !isGameOver)
        {
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
        if (collision.gameObject.CompareTag("JumpingPlatform"))
        {
            playerRigidBody2D.AddForce(Vector3.up*platformForce,ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            isGameOver=true;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround=true;
            Debug.Log("The player is on Platform");
            isOnPlatform=true;
            transform.SetParent(collision.transform);
        }
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
        if (collision.gameObject.CompareTag("Cherry"))
        {
            health=health+12;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            health=health+14;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Melon"))
        {
            health=health+16;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("EnemyBlock") || collision.gameObject.CompareTag("Demon"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Level3");
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            // playerRigidBody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            isGameOver=true;
            // Animator animator = collision.gameObject.GetComponent<Animator>();
            // AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            // if (stateInfo.IsName("SlimeAttack"))
            // {
            //     Debug.Log("Slime is attacking");
            //     SceneManager.LoadScene("Level2");
            // }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}
