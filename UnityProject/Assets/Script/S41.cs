using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S41 : MonoBehaviour
{

    public GameObject yesButton;
    public Text text;
    //public GameObject textLayout;
    public GameObject endButton;
    public Image image;
    public Sprite[] sprites;
    public AudioClip[] audioClips;
    AudioSource audioSource;
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
        audioSource = GetComponent<AudioSource>();
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
        AudioStart(dialogIndex);
        StartCoroutine(TypeText(a));
    }
    void InitializeText()
    {
        string[] b = {
             "经过病毒研究所的不断研究，中国的新冠疫苗经过临床多期试验，已经成功进行生产。"
            };
        arrayList.Add(b);

        string[] a = {
             "现如今，我国的疫苗工厂生产效率极高，疫苗已经送往世界各地。"
            };
        arrayList.Add(a);

        string[] c =
        {
            "中国疫苗实现了全民免费，疫苗的高保护率保障了我们的生命安全。"
        };
        arrayList.Add(c);


    }
    /// <summary>
    /// 按间隔显示每一个String
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    private IEnumerator TypeText(string[] a)
    {
        StaticScript.talkSpace = 0.15f;
        StaticScript.Yes = false;
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
    public void AudioStart(int index)
    {

        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
