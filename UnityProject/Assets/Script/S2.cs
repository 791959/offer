using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class S2 : MonoBehaviour
{

    public GameObject yesButton;
    public Text text;
    //public GameObject textLayout;
    public GameObject endButton;
    public Image image;
    public Sprite[] sprites;
    public GameObject[] layout;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    public S24 aa;
    public S31 bb;
    public S41 cc;
    public S51 dd;
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
       

    }
    public void AudioStart(int index)
    {
        if (audioClips.Length > 0)
        {
 audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
        }
       
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
             "王医生是湖南省长沙市湘雅第一医院一名主治医生。"
            };
        arrayList.Add(b);

        string[] a = {
             "在2020年1月23日，王医生接到组织的安排，随湖南第一批赴湖北医疗队，王医生匆匆和孩子道别就踏上了去湖北的列车."
            };
        arrayList.Add(a);

        string[] c =
        {
            "2020年1月25日医疗队刚刚到达武汉，还没来得及歇息，刚下车就坐上了去武汉第一医院的大巴车。一路颠簸终于到了医院，经过系列检查后，都穿上了厚重的防护服，虽然可以正常呼吸，但是头部有强烈的压迫感，酸痛而炙热 。"
        };
        arrayList.Add(c);
        string[] d = {
             "很快大家就去了分配的岗位上工作，假如你是王医生，你能完成接下来分配的任务吗."
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
    public void OnSmallSceneCLick()
    {
        for(int i = 0; i < layout.Length; i++)
        {
            if (i == 0)
                layout[i].SetActive(true);
            else
                layout[i].SetActive(false);
        }
        audioSource.Stop();
    }
    public void OnChapterButtonClick(int index)
    {
        for (int i = 0; i < layout.Length; i++)
        {
            if (i == index)
            {
                if (i == 1)
                {
                    layout[i].SetActive(true);
                    dialogIndex = 0;
                    ShowDialog(arrayList[dialogIndex] as string[]);
                }
                    
                else if (i == 4)
                {

                    layout[i].SetActive(true);
                    aa.SHow();
                }
                else
                    layout[i].SetActive(true);


            }
                
            else
                layout[i].SetActive(false);
        }
    }

    public void OnButtonClickSHow(int i)
    {
        layout[i].SetActive(true);
        bb.SHow();
    }
    public void OnS41Show(int i)
    {
        layout[i].SetActive(true);
        cc.SHow();
    }
    public void OnS51Show(int i)
    {
        layout[i].SetActive(true);
        dd.SHow();
    }
    public void OnButtonClickLoadGame()
    {
        SceneManager.LoadScene(7);
    }
    public void OnVirusGame()
    {
        SceneManager.LoadScene(8);
    }
    public void OnBirdGame()
    {
        SceneManager.LoadScene(9);
    }

}
