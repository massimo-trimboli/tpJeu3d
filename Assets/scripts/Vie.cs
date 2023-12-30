using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Vie : MonoBehaviour
{
    public static float hp = 100f;
    public GameObject barreVie;

    public static int compteurEnemi;
    public TMP_Text textEnemi;

    //etaindre le curseur
    public bool cursorOff;

    void Start()
    {
        if (cursorOff)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        GameObject[] enemis = GameObject.FindGameObjectsWithTag("enemi");
        compteurEnemi = enemis.Length;
    }

    void Update()
    {
        //baiser la barre de vie
        barreVie.GetComponent<Image>().fillAmount = hp / 100;

        if(hp < 0)
        {
            
        }

        //actualiser le compteur
        textEnemi.text = compteurEnemi.ToString();

        //finir le jeu quand 
        if (compteurEnemi == 0)
        {
            SceneManager.LoadScene("fin");
        }
    }
}
