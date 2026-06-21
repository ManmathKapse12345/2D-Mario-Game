using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private float xMin=0f;
    private float xMax=400f;
    private float yMin;
    private float yMax=30f;
    private float xPos;
    private float yPos;
    private bool isOnPlatform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Level1" || sceneName == "Level2")
        {
            yMin=5.52f;
        }
        if (sceneName == "Level3")
        {
            yMin=-15f;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        isOnPlatform = player.GetComponent<Player>().isOnPlatform;
        xPos=Mathf.Clamp(player.transform.position.x,xMin,xMax); 
        yPos = Mathf.Clamp(player.transform.position.y,yMin,yMax);
        transform.position=new Vector3(xPos,yPos,gameObject.transform.position.z);
        // transform.position=new Vector3(xPos,gameObject.transform.position.y,gameObject.transform.position.z);
        if (isOnPlatform)
        {
            Debug.Log("The player is on Platform");
            transform.position=new Vector3(xPos,yPos,transform.position.z);
        }
    }
}
