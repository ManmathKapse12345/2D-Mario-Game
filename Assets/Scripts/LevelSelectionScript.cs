using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class LevelSelectionScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image image;
    public Color normalColor = Color.blue;
    public Color hoverColor = Color.red;
    private string level;

    private TMP_Text levelText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        // levelText=GetComponentInChildren<TMP_Text>();
        // level = levelText.text.Replace(" ","");
    }

    // Update is called once per frame

    public void SelectLevel1()
    {
        // Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level1");
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void SelectLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void SelectLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
}
