using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScript : MonoBehaviour
{
    private float speed = 5f;
    public GameObject leftWallObject;
    public GameObject rightWallObject;
    private Vector2 targetWallObject;
    private Animator animator;
    private bool isAttacking=false;
    // private Player playerScript = 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        targetWallObject = new Vector2(rightWallObject.transform.position.x,transform.position.y); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position,targetWallObject,speed*Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, targetWallObject) < 0.5f && !isAttacking)
        {
            Debug.Log("Changing Direction");
            targetWallObject.x = (targetWallObject.x==rightWallObject.transform.position.x)?leftWallObject.transform.position.x:rightWallObject.transform.position.x;
            FlipEnemy();
        }
    }
    void FlipEnemy()
    {
        Vector3 localScaleEnemy = transform.localScale;
        // float directionX = localScaleEnemy.x;
        transform.localScale = new Vector3(-localScaleEnemy.x,localScaleEnemy.y,localScaleEnemy.z);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Monster collided outside if");
        if(collision.gameObject.CompareTag("Player") && !isAttacking)
        {
            Debug.Log("Monster Collided inside if");
            isAttacking=true;
            animator.SetBool("doAttack",true);
            StartCoroutine(ReloadSceneAfterAttack());
        }
        // isAttacking=true;
    }
    private IEnumerator ReloadSceneAfterAttack()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // animator.SetBool("doAttack",true);
        
        if (stateInfo.IsName("SlimeWalk"))
        {
            yield return null;
        }
        Debug.Log(stateInfo.length);
        yield return new WaitForSeconds(stateInfo.length+0.6f);
        SceneManager.LoadScene("Level2");
    }
}
