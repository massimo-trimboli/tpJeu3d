using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie : MonoBehaviour
{
    public static float hp = 100f;
    public GameObject barreVie;

    public static int compteurEnemi;

    //etaindre le curseur
    public bool cursorOff;

    void Start()
    {
        if (cursorOff)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
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
    }
}
