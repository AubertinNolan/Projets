using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    bool isPaused = false;
    public GameObject menuPause;
    public static int amisRestants = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                menuPause.SetActive(isPaused);
                Time.timeScale = 1f; //Permet de revenir au temps de jeu normal
            }
            else
            {
                isPaused = true;
                menuPause.SetActive(isPaused);
                Time.timeScale = 0f; //Permet d'arrêter le temps en jeu
            }
        }
    }
}
