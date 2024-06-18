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
       

        

        if(Vector3.Distance(transform.position, target.position) < 0.3f){
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            FlipEnemy();
            
        }
        
    }
    void FlipEnemy(){
        Vector3 newRotation = Sprite.eulerAngles;

    // Inverser la rotation de 180 degrés sur l'axe Y
        newRotation.y += 180f;

    // Appliquer la nouvelle rotation au sprite
        Sprite.eulerAngles = newRotation;
    }
}
