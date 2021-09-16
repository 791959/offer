using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // GameObject.Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pig")
        {
            GameObject.Destroy(collision.gameObject);
            Destroy(this.gameObject,3);
        }
    }
}
