using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    public GameObject rifle1;
    public GameObject rifle2;
    int currentRifle = 1;
    public static bool avoirFusil = false;

    public GameObject bullet;
    public float vitesseBalle;

    private void Start()
    {
        bullet.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (avoirFusil))
        {
            Tirrer();
        }
    }

    void Tirrer()
    {
        //alterner de fusil chaque fois
        if(currentRifle == 1)
        {
            //jouer lanimation du tir
            rifle1.GetComponent<Animator>().SetTrigger("tirer");

            currentRifle = 2;
        }
        else if(currentRifle == 2)
        {
            //jouer lanimation du tir
            rifle2.GetComponent<Animator>().SetTrigger("tirer");

            currentRifle = 1;
        }

        //tirrer une balle
        GameObject uneBalle = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
        uneBalle.SetActive(true);
        uneBalle.GetComponent<Rigidbody>().velocity = bullet.transform.forward * vitesseBalle;
    }
}
