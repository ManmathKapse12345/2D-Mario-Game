using TMPro;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    private Player playerScript;
    public TMP_Text healthStatus;
    public Camera mainCamera;
    private int healthValue;
    public float xPos;
    public float yPos;
    public float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
        offsetY=healthStatus.transform.position.y-mainCamera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = mainCamera.transform.position.x;
        yPos=mainCamera.transform.position.y+offsetY;
        healthStatus.transform.position=new Vector2(xPos,yPos);
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
        if (playerScript.isGameOver)
        {
            healthStatus.text=healthStatus.text+"\nCongratulations You have Completed Level!";
        }
    }
}
