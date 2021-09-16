using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class one : MonoBehaviour
{
    public Text timeText;
    public Text winfalse;
    public GameObject[] imagePos;
    public GameObject end;

    int timeindex=0;
    int time = 0;
    int[] a ={
            0,0,0,
            3,1,3,
            3,3,1,
            2,3,3,
            0,0,0

        };
    string[] timet =
    {
        "8:00",
        "12:00",
        "14:00",
        "16:00",
        "18:00"
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
        if (index >14 )
        {
            end.SetActive(true);
        }
        else
        {
            index++;
            timeindex++;
            if (timeindex == 3)
            {
                time++;
                timeindex = 0;
            }
            if (a[index] == i)
            {
                winfalse.text = "成功";
            }
            else
            {
                winfalse.text = "失败";
            }


            int k = index % 3 + 1;
            Debug.Log(index % 3);

            if (k > 2)
                k = 0;

            Debug.Log(k);

            for (int j = 0; j < imagePos.Length; j++)
            {
                if (j == k)
                    imagePos[j].SetActive(true);
                else
                    imagePos[j].SetActive(false);
            }

            timeText.text = timet[time];
        }
        

        
    }
}
