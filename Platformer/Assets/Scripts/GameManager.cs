using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    
     public GameObject uiCanvas;
    private int vie = 3;
    // Start is called before the first frame update

     private void Awake()
    {
        // Check if an instance of GameManager already exists
        if (instance == null)
        {
            // If not, set the instance to this GameManager
            instance = this;

            // Optionally, mark the GameManager to not be destroyed on scene load
            
        }
        else
        {
            // If an instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }
    void Start()
    {
        uiCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        uiCanvas.SetActive(false);

        if (vie <= 0 ){
            Debug.Log("c'est perdu");
            GameOver();
        }
    }

    public void GameOver(){
         uiCanvas.SetActive(true);
         
         Time.timeScale = 0f; // Arrête complètement le jeu
         if(Input.GetKeyDown(KeyCode.Space)){
            RestartGame();
         }
    }
    public void LoseHealth(){
        vie -= 1;
        Debug.Log("Touché");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Remet le temps à l'écoulement normal
        // Code pour recharger la scène actuelle ou retourner au menu principal
        // Exemple pour recharger la scène actuelle :
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
