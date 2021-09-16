using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BeginScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Page;
    public GameObject levelPage;
    public GameObject customPage;
    public Sprite[] sprites;
    public Image image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLoadSceneCLick(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void OnPageButtonClick(bool i)
    {
        Page.SetActive(i);
    }
    public void OnLevelButtonClick(bool i)
    {
        levelPage.SetActive(i);
    }
    public void OnCustomButtonClick(bool i)
    {
        customPage.SetActive(i);
    }
    public void OnChangeClothButtonCLick(int i)
    {
       
        image.sprite = sprites[i];
    }
}
