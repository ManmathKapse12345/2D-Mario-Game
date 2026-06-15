using TMPro;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    private Player playerScript;
    public TMP_Text healthStatus;
    public Camera mainCamera;
    private int healthValue;
    public float xPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = mainCamera.transform.position.x;
        healthStatus.transform.position=new Vector2(xPos,healthStatus.transform.position.y);
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
    }
}
