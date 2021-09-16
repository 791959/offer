using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FollowCam : MonoBehaviour
{
    public static FollowCam S;
    public float easing = 0.05f;

    public GameObject target;
    Vector3 camOriginalPos;
    private void Awake()
    {
        S = this;
        camOriginalPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 destPos = Vector3.Lerp(transform.position, target.transform.position, easing * Time.deltaTime);
        destPos.x = Mathf.Max(0, destPos.x);
        destPos.y = camOriginalPos.y;
        destPos.z = camOriginalPos.z;

        transform.position = destPos;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            if (target.GetComponent<Rigidbody2D>().IsSleeping())
            {
                target = null;
                transform.position = camOriginalPos;
                return;
            }
        }
    }
    public void OnReturn()
    {
        SceneManager.LoadScene(4);
    }
}
