using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }
    }
}
