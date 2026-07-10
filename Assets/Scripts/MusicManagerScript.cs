using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    // private const int levelNumber = 5;
    private Player playerScript;
    private AudioSource audioSources;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSources = GetComponent<AudioSource>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.isPause)
        {
            audioSources.Pause();
        }
        else
        {
            audioSources.UnPause();
        }
        
    }
}
