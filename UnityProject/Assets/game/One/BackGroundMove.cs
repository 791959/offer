using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.localPosition.y > -1003)//背景图 没有显示终点的时候自动移动
            this.transform.position += Vector3.down * speed;
        else

            this.transform.localPosition = new Vector3(0,1483, 0);
    }
}
