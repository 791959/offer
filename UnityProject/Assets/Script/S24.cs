using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S24 : MonoBehaviour
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
        audioSource = GetComponent<AudioSource>();
        InitializeText();

        ShowDialog(arrayList[dialogIndex] as string[]);
    }
    public void SHow()
    {
        endButton.SetActive(false);
        dialogIndex = 0;
        ShowDialog(arrayList[dialogIndex] as string[]);
    }
    public void AudioStart(int index)
    {

        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
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
             "新增病例越来越少了，每天的任务也越来越轻松，看到康复的病人们的笑脸，病毒虽冷，人情却暖。"
            };
        arrayList.Add(b);

        string[] a = {
             "2020年3月8日13时30分 武汉体育中心方舱医院送走最后一批13名患者，正式休舱。"
            };
        arrayList.Add(a);

        string[] c =
        {
            "现在医疗队在武汉的高铁站，准备回家了，大家都面带笑容。"
        };
        arrayList.Add(c);
        string[] d = {
             "终于到了能和家人团聚的时刻了。"
            };
        arrayList.Add(d);


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
    public void OnBUtttonClick()
    {
        dialogIndex = 0; InitializeText();
        ShowDialog(arrayList[dialogIndex] as string[]);
    }

}
