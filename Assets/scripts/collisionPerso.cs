using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPerso : MonoBehaviour
{
    public float forceColision;
    public float drag;


    private void Start()
    {
        drag = GetComponent<Rigidbody>().drag;
    }


    private void OnCollisionEnter(Collision infoCollision)
    {
        if( infoCollision.gameObject.tag == "projectile" )
        {
            //desactiver le mouvement du perso
            ToggleControl();
            //lancer le joueur dans la meme direction que le projectile
            GetComponent<Rigidbody>().velocity = infoCollision.gameObject.GetComponent<Rigidbody>().velocity * forceColision;
            GetComponent<Rigidbody>().AddRelativeForce(0, 2500, 0);
            //activer le mouvement du perso
            Invoke("ToggleControl", 1.5f);
        }
    }

    void ToggleControl()
    {
        if(GetComponent<characterController3PS>().enabled == true)
        {
            GetComponent<characterController3PS>().enabled = false;
            GetComponent<Rigidbody>().drag = 0;
        }
        else
        {
            GetComponent<characterController3PS>().enabled = true;
            GetComponent<Rigidbody>().drag = drag;
        }
    }
}
