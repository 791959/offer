using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S31 : MonoBehaviour
{

    public GameObject yesButton;
    public Text text;
    //public GameObject textLayout;
    public GameObject endButton;
    public Image image;
    public AudioClip[] audioClips;
    AudioSource audioSource;
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
    public void AudioStart(int index)
    {

        if (audioSource)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
        
    }
    void InitializeText()
    {
        arrayList.Clear();
        string[] b = {
             "2020年5月11日湖北省武汉市病毒研究所正在举行一场新冠病毒疫苗专题报告会。"
            };
        arrayList.Add(b);

        string[] a = {
             "新冠病毒的感染，源于一次偶然的相遇也许是空气中的飞沫，也许是一次没有洗手就揉眼睛，病毒就会通过身体各处的粘膜进入人体内。"
            };
        arrayList.Add(a);

        string[] c =
        {
            "新型冠状病毒之所以传染性强，就是因为他们有血管紧张转化酶2：病毒可以凭借这种受体，与同样含有这种酶的粘膜细胞完成受体结合，侵入细胞内部；",
            "病毒进入细胞后，释放自己的遗传物质RNA，把整个细胞变成病毒的生产基地。成千上万的病毒被制造出来，不断的运送到细胞外再感染其他细胞，这个过程有长有短，期间人体不会有明显症状，这就是潜伏期。"
        };
        arrayList.Add(c);
        string[] d = {
             "病毒沿着口鼻处的粘膜，蔓延到咽喉、气管、支气管，并开始攻击肺部，免疫系统开始发生应答，白细胞单核细胞，树突状细胞，巨噬细胞，淋巴细胞开始工作，消除病毒。"
            };
        arrayList.Add(d);

        string[] e = {
             "在巨噬细胞清除病毒过程中，会将病毒入侵的信息上报给大脑，大脑会启动人体紧急响应，此时人体会产生一些不舒适比如浑身酸痛、嗜睡、发热、喉咙红肿等现象，但别担心，这些都是好转的正常现象。"
            };
        arrayList.Add(e);
        string[] f = {
             "但是这次的新冠病毒非常狡猾，他们的一种特殊蛋白质能让免疫系统发生错误判断，把部分人体细胞当成敌人并展开攻击，那些原本有心脏病、糖尿病等症状的感染者，由于免疫系统错误的攻击，可能会导致死亡。"
            };
        arrayList.Add(f);
        string[] g = {
             "虽然病毒很狡猾，但在医护人员的救治下，我们体内的细胞也变得更加强大淋巴细胞们识别病毒，产生专一性抗体，在消除病毒结束后，部分残留的记忆T细胞和记忆B细胞生产的抗体一直在体内防止我们再次感染病毒。"
            };
        string[] h = {
             "战争落幕后，只需要一些时间耐心等待，那些死去的细胞就会重新生长出来，人体就会恢复健康。"
            };
        arrayList.Add(g);
        arrayList.Add(h);


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
        dialogIndex = 0;
        InitializeText();
        ShowDialog(arrayList[dialogIndex] as string[]);
        endButton.SetActive(false);
    }
}
