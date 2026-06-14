// using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public bool isRight=false;
    public float translationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        if((horizontalInput>0 && isRight) || (horizontalInput<0 && !isRight))
        {
            FlipPlayer();
        }
        transform.Translate(Vector3.right*Time.deltaTime*translationSpeed*horizontalInput);
        
    }

    void FlipPlayer()
    {
        isRight=!isRight;
        Vector3 localScalePlayer = transform.localScale;
        localScalePlayer.x=localScalePlayer.x*-1;
        transform.localScale=localScalePlayer;
    }
}
