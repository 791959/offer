using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class MainScene : MonoBehaviour
{
    public Image firstPage;
    public GameObject[] secondThirdLayout;
    public Transform content;
    Color temp;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticScript.firstIn)
        {
            temp = firstPage.color;
            StartCoroutine(Hide());
            StaticScript.firstIn = false;
        }
        else
        {
            secondThirdLayout[1].SetActive(true);
            firstPage.gameObject.SetActive(false);
        }
        
        content.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnbeginButtonClick(int i)
    {
        for(int j = 0; j < secondThirdLayout.Length; j++)
        {
            if (j == i)
                secondThirdLayout[j].SetActive(true);
            else
                secondThirdLayout[j].SetActive(false);
        }
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(2f);
        float a = 1;
        while (firstPage.color.a >= 0)
        {
            a -= Time.deltaTime ;
            firstPage.color = new Color(temp.r, temp.g, temp.b, a);
        yield return 0;
        }
        firstPage.gameObject.SetActive(false);
    }
    public void OQuit()
    {
        Application.Quit();
    }
    public void Mute()
    {
        flag = !flag;
        if (flag)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
}
