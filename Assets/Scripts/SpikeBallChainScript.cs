using UnityEngine;

public class SpikeBallChainScript : MonoBehaviour
{
    public GameObject centralObject;
    private float minAngle=-45f;
    private float maxAngle=45f;
    private float speed = 50f;
    private int direction =1;
    private float currentAngle=0f;
    public float radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius=Vector3.Distance(transform.position,centralObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += direction*speed*Time.deltaTime;
        if (currentAngle >= maxAngle)
        {
            currentAngle=maxAngle;
            direction=-1;
        }
        else if (currentAngle <= minAngle)
        {
            currentAngle=minAngle;
            direction=1;
        }
        float rad = currentAngle*Mathf.Deg2Rad;
        transform.position = centralObject.transform.position + new Vector3(radius*Mathf.Sin(rad),-radius*Mathf.Cos(rad),0);
        
    }
}
