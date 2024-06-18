using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    public float speed = 10.0f;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // moitié de la largeur de l'objet
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // moitié de la hauteur de l'objet
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {

        bool isMovingUp = true;
        
        Vector3 newPosition = transform.position;

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            newPosition += Vector3.left * speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            newPosition += Vector3.right * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            
            newPosition += Vector3.up * speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            isMovingUp = false;
            newPosition += Vector3.down * speed * Time.deltaTime;
        }

        // Restreindre la position du personnage aux limites de l'écran
        float clampedX = Mathf.Clamp(newPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        float clampedY = Mathf.Clamp(newPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = new Vector3(clampedX, clampedY, newPosition.z);

        animator.SetBool("IsMovingUp", isMovingUp);


        
        
    }
    void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Enemy") {
                Debug.Log("Touché");
                if (GameManager.instance != null)
                {
                    GameManager.instance.LoseHealth();
                }
            }
        }
}
