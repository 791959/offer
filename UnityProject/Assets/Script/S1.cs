using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S1 : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject yesButton;
    public Text text;
    public GameObject textLayout;
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
        audioSource = this.GetComponent<AudioSource>();
        InitializeText();
        ShowDialog(arrayList[0] as string[]);

    }
    public void AudioStart(int index)
    {

        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            dialogIndex = 0;
            ShowDialog(arrayList[0] as string[]);
        }
    }
    /// <summary>
    /// 显示每
    /// </summary>
    /// <param name="a"></param>
    public void ShowDialog(string[] a)
    {
        image.sprite = sprites[dialogIndex];
        textLayout.SetActive(true);
        yesButton.SetActive(false);
        StopAllCoroutines();
        text.text = "";
        AudioStart(dialogIndex);
        StartCoroutine(TypeText(a));
    }
    void InitializeText()
    {
        string[] b = {
             "春节，本来应该是一年中团团圆圆最快乐的一段时光，可是2020年的农历春节，大概是中国人，21世纪来过的最不喜庆的一个春节。"
            };
        arrayList.Add(b);

        string[] a = {
             "                         "
            };
        arrayList.Add(a);

        string[] c =
        {
            "曾经过年期间的走街访友也变成了闭门不出、谢绝亲友，每个人都绷紧了神经。"
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
}
