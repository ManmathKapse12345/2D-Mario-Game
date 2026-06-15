using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private float xMin=0f;
    private float xMax=50f;
    private float xPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        xPos=Mathf.Clamp(player.transform.position.x,xMin,xMax); 
        transform.position=new Vector3(xPos,gameObject.transform.position.y,gameObject.transform.position.z);
    }
}
