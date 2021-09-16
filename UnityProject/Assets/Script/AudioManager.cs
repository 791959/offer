using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip[] gameStart;
    public AudioClip[] S24;
    Dictionary<string, AudioClip> keyValuePairsAudio = new Dictionary<string, AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;

        Debug.Log(Application.streamingAssetsPath);
        // GetFiles("Assets/Resources/Audio");
        //foreach(var a in keyValuePairsAudio)
        //{
        //    Debug.Log(a);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play(string name, AudioSource audioSource)
    {
        if (keyValuePairsAudio.ContainsKey(name))
        {
            audioSource.clip = keyValuePairsAudio[name];
            //StartCoroutine(StopPlay(audioSource, 1f));
            audioSource.Play();
        }
        else
        {
            Debug.LogError("notFind");
        }

    }
    public void Play(AudioSource audioSource)
    {

      audioSource.clip = audioClip;
        //StartCoroutine(StopPlay(audioSource, 1f));
        audioSource.Play();


    }


    public void GameStart(int index)
    {

        audioSource.Stop();
            audioSource.clip = gameStart[index];
            audioSource.Play();
        

    }
    public void S24GameStart(int index)
    {

        audioSource.Stop();
        audioSource.clip = S24[index];
        audioSource.Play();


    }

    IEnumerator StopPlay(AudioSource audioSource, float i)
    {
        audioSource.Play();
        yield return new WaitForSeconds(i);
        audioSource.Stop();
    }
    public void GetFiles(string path)
    {
        //string path = string.Format("{0}", Application.streamingAssetsPath );
        //string path = string.Format("{0}", @"C:\Users\USER\Desktop\JXBWG\Assets\StreamingAssets");

        //获取指定路径下面的所有资源文件  
        if (Directory.Exists(path))
        {
            DirectoryInfo direction = new DirectoryInfo(path);
            FileInfo[] files = direction.GetFiles("*");
            for (int i = 0; i < files.Length; i++)
            {
                //忽略关联文件
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                //Debug.Log("文件名:" + files[i].Name);
                //Debug.Log("文件绝对路径:" + files[i].FullName);
                //Debug.Log("文件所在目录:" + files[i].DirectoryName);

                AudioClip go = Resources.Load("Audio/" + files[i].Name.Split('.')[0], typeof(AudioClip)) as AudioClip;
                string name = files[i].Name.Split('.')[0];
                Debug.Log(name);
                keyValuePairsAudio.Add(name, go);
            }
        }
        else
        {
            Debug.Log("No");
        }
    }
}
