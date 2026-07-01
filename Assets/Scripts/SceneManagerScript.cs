using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    private Player playerScript;
    public TMP_Text healthStatus;
    public Button pauseButton;
    public Camera mainCamera;
    private int healthValue;
    public float xPos;
    public float yPos;
    public float healthStatusOffsetY;
    public float healthStatusOffsetX;
    public float pauseStatusOffsetX;
    public float pauseStatusOffsetY;
    private bool isPause;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        // isPause = playerScript.isPause;
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
        healthStatusOffsetY=healthStatus.transform.position.y-mainCamera.transform.position.y;
        healthStatusOffsetX=healthStatus.transform.position.x-mainCamera.transform.position.x;
        pauseStatusOffsetX=pauseButton.transform.position.x-mainCamera.transform.position.x;
        pauseStatusOffsetY=pauseButton.transform.position.y-mainCamera.transform.position.y;
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerScript.isPause)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
        xPos = mainCamera.transform.position.x+healthStatusOffsetX;
        yPos=mainCamera.transform.position.y+healthStatusOffsetY;
        healthStatus.transform.position=new Vector2(xPos,yPos);
        pauseButton.transform.position = new Vector2(mainCamera.transform.position.x+pauseStatusOffsetX,mainCamera.transform.position.y+pauseStatusOffsetY);
        healthValue=playerScript.health;
        healthStatus.text="Health :- "+healthValue;
        if (playerScript.isGameOver && playerScript.levelCompleted)
        {
            healthStatus.text=healthStatus.text+"\nYou have Completed "+SceneManager.GetActiveScene().name;
        }
    }


    public void MakeGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MakeGameQuit()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
