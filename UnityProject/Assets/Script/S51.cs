using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S51 : MonoBehaviour
{

    public GameObject yesButton;
    public Text text;
    //public GameObject textLayout;
    public GameObject endButton;
    public Image image;
    public Sprite[] sprites;
    // public GameObject textLayout;

    [HideInInspector]
    /// <summary>
    /// 对话下标
    /// </summary>
    int dialogIndex;
    //public static NPCTextChoose instance;
    public ArrayList arrayList = new ArrayList();
    /// <summary>
    /// 鼠标是否点击
    /// </summary>
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StaticScript.talkSpace = 0.01f;
        }
    }
    void Start()
    {
        InitializeText();

        ShowDialog(arrayList[dialogIndex] as string[]);
    }


    /// <summary>
    /// 显示每
    /// </summary>
    /// <param name="a"></param>
    public void ShowDialog(string[] a)
    {
        image.sprite = sprites[dialogIndex];
        // textLayout.SetActive(true);
        yesButton.SetActive(false);
        StopAllCoroutines();
        text.text = "";
        StartCoroutine(TypeText(a));
    }
    void InitializeText()
    {
        arrayList.Clear();
        string[] b = {
             "                "
            };
        arrayList.Add(b);
        arrayList.Add(b);
        arrayList.Add(b);
        arrayList.Add(b);
        arrayList.Add(b);
        arrayList.Add(b);
        arrayList.Add(b);




    }
    /// <summary>
    /// 按间隔显示每一个String
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    private IEnumerator TypeText(string[] a)
    {
        StaticScript.Yes = false;
        StaticScript.talkSpace = 0.15f;
        //Debug.Log(a.Length);
        if (a.Length > 1)
        {
            for (int i = 0; i < a.Length; i++)
            {
                text.text = "";
                foreach (char letter in a[i].ToCharArray())
                {
                    text.text += letter;
                    yield return new WaitForSeconds(StaticScript.talkSpace);
                }
                yield return new WaitForSeconds(StaticScript.talkSpace);
            }
        }
        else
        {
            text.text = "";
            string temp = a[0];
            //Debug.Log(temp);
            foreach (char letter in temp.ToCharArray())
            {
                text.text += letter;
                yield return new WaitForSeconds(StaticScript.talkSpace);
            }
        }
        dialogIndex++;
        yesButton.SetActive(true);
        while (!StaticScript.Yes)
        {
            yield return 0;
        }

        if (dialogIndex < arrayList.Count)
            ShowDialog(arrayList[dialogIndex] as string[]);
        else
            endButton.SetActive(true);

    }
    public void SHow()
    {
        dialogIndex = 0; InitializeText();
        ShowDialog(arrayList[dialogIndex] as string[]);
        endButton.SetActive(false);
    }
}
