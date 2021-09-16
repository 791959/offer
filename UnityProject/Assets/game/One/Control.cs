using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    public float speed;
    public GameObject[] WFS;
    float vertical, horizontal;
    Vector2 dir;

    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mousePosition.y < 1500 && Input.GetMouseButtonDown(0) && flag)
        {
            Move();
        }

    }
    /// <summary>
    /// 
    /// 船移动的函数
    /// </summary>
    void Move()
    {
        // vertical = Input.GetAxis("Vertical");
        //horizontal = Input.GetAxis("Horizontal");
        if (Input.mousePosition.x < this.transform.position.x)
        {
            dir = new Vector2(-0.7f, 1);
            //this.transform.Rotate(0, 180, 0);
           
        }
        else
        {
           
            dir = new Vector2(0.7f, 1);

        }

        this.GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// 
    /// 碰撞检测函数，
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Die")
        {
            WFS[1].SetActive(true);
            flag = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.down*500;
        }
    }
    public void OnSettingButtonClick(bool i)
    {
        WFS[2].SetActive(i);
        if (i == false)
        {
            Time.timeScale = 1;
            flag = true;
        }

        else
        {
            flag = false;
        }

    }
    public void OnSceneChange(int i)
    {
        SceneManager.LoadScene(i);
    }


}
