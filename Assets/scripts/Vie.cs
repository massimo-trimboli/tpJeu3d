using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie : MonoBehaviour
{
    public static float hp = 100f;
    public GameObject barreVie;


    // Update is called once per frame
    void Update()
    {
        //baiser la barre de vie
        barreVie.GetComponent<Image>().fillAmount = hp / 100;

        if(hp < 0)
        {
            
        }
    }
}
