using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlanete : MonoBehaviour
{
    public GameObject objet = null;


    //quand on entre dans le champ gravitationel de la planete
    //ajouter la planete comme cible a lobjet
    void OnTriggerEnter(Collider infoCollision)
    {
        objet = infoCollision.gameObject;

        if (objet.name != "vaisseau")
        {
            objet.GetComponent<gravite>().planet = gameObject;
        }
        else
        {
            //a faire plus tard
        }

        //allumer la gravite
        objet.GetComponent<Rigidbody>().useGravity = false;
    }


    //quand on sors du champ gravitationel de la planete
    //enlever la cible de lobjet qui quitte la planete
    private void OnTriggerExit(Collider infoCollision)
    {
        objet = infoCollision.gameObject;
        objet.GetComponent<gravite>().planet = null;

        //etteindre la gravite
        objet.GetComponent<Rigidbody>().useGravity = true;
    }
}
