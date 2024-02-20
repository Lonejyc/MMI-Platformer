using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemy : MonoBehaviour
{

    public float speed;
    public Transform[] wayPoints;

    public Transform Sprite;

    public Vector3 rotation;
    private Transform target;
    private int destPoint;
    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World );
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = lookRotation.eulerAngles;

        

        if(Vector3.Distance(transform.position, target.position) < 0.3f){
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            Sprite.rotation = Quaternion.Euler(0f, rotation.y+180, 0f);
            
        }
    }
}
