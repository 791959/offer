using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class twog : MonoBehaviour
{
    public Text timeText;
    public Text winfalse;
    public GameObject[] imagePos;
    public GameObject end;

    int timeindex = 0;
    int time = 0;
    int[] a ={
            1,0,2

        };
    string[] aa =
    {
        "病人1：头晕嗜睡身体酸痛 ",
        "病人2：除了核酸检测阳性无明显症状",
        "病人3：呼吸困难且发高烧"
    };
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnbuttonClick(int i)//i = 0 1 2 3
    {
        if (index > 2)
        {
            end.SetActive(true);
        }
        else
        {
            index++;
            if(index+1<3)
            timeText.text = aa[index+1];
            if (a[index] == i)
            {
                winfalse.text = "成功";
            }
            else
            {
                winfalse.text = "失败";
            }
            imagePos[(index)].SetActive(true);
        }



    }
}
