using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class NewBehaviourScript : MonoBehaviour
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
        a += Time.deltaTime;
        rawImage.texture = videoPlayer.texture;
        if (a > 44f)
            this.gameObject.SetActive(false);

        if ( Input.GetMouseButtonDown(0)&&this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
}
