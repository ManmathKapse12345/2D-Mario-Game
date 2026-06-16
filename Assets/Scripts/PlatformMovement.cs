using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private int yMin=3;
    private int yMax = 12;
    private Vector2 targetPos;
    private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = new Vector2(transform.position.x,yMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
        if (transform.position.y == targetPos.y)
        {
            targetPos.y = (targetPos.y==yMax)?yMin:yMax;
        }
    }
}
