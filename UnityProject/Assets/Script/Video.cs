using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    VideoPlayer videoPlayer;
    RawImage rawImage;
    float a;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();
        rawImage.texture = videoPlayer.texture;
        a = Time.time;
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
      //  a += Time.deltaTime;
            rawImage.texture = videoPlayer.texture;
        //if (a > 12f)
           // this.gameObject.SetActive(false);
    }
    public void OnButtonClick()
    {
    }
}
