using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Jouer()
    {
        scriptMusiqueMenu.arreterMusique();
        Vie.hp = 100;
        SceneManager.LoadScene("Jeu");
    }
    public void controls()
    {
        SceneManager.LoadScene("controls");
    }
    public void Intro()
    {
        SceneManager.LoadScene("intro");
    }
}
