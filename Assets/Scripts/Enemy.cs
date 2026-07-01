using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed=5f;
    public GameObject leftWallObject;
    public GameObject rightWallObject;
    private Vector2 targetWallObject;

    private Player playerScript;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        targetWallObject = new Vector2(leftWallObject.transform.position.x,transform.position.y); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isPause)
        {
            transform.position = Vector2.MoveTowards(transform.position,targetWallObject,speed*Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, targetWallObject) < 0.5f)
        {
            // Debug.Log("Changing Direction");
            targetWallObject.x = (targetWallObject.x==rightWallObject.transform.position.x)?leftWallObject.transform.position.x:rightWallObject.transform.position.x;
            if (gameObject.CompareTag("EnemyBlock") || gameObject.CompareTag("Demon"))
            {
                FlipEnemy();
            }
        }
    }

    void FlipEnemy()
    {
        Vector3 localScaleEnemy = transform.localScale;
        // float directionX = localScaleEnemy.x;
        transform.localScale = new Vector3(-localScaleEnemy.x,localScaleEnemy.y,localScaleEnemy.z);
    }
}
