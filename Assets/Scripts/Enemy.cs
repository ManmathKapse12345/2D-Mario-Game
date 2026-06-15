using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed=5f;
    private float xTarget=1;
    public GameObject leftWallObject;
    public GameObject rightWallObject;
    private Vector2 targetWallObject;
    private Vector2 leftPosition;
    private Vector2 rightPosition;
    // private Vector3 leftPoint = new Vector3(7.56f,3.73f,0);
    // private Vector3 rightPoint= new Vector3(14.48f,2.94f,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // targetWallObject=rightWallObject;
        targetWallObject = new Vector2(rightWallObject.transform.position.x,transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetWallObject,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWallObject) < 2f)
        {
            Debug.Log("Changing Direction");
            targetWallObject.x = (targetWallObject.x==rightWallObject.transform.position.x)?leftWallObject.transform.position.x:rightWallObject.transform.position.x;
        }
    }
}
