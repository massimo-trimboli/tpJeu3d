using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPerso : MonoBehaviour
{
    public float forceColision;
    public float drag;

    public GameObject rifle1;
    public GameObject rifle2;

    private void Start()
    {
        drag = GetComponent<Rigidbody>().drag;
        rifle1.SetActive(false);
        rifle2.SetActive(false);
    }

    //tuer si tomber
    void Update()
    {
        if (transform.position.y < -88)
        {
            Vie.hp = 0;
        }
    }


    private void OnCollisionEnter(Collision infoCollision)
    {
        if( infoCollision.gameObject.tag == "projectile" )
        {
            //baisser la barre de vie
            Vie.hp -= 50;
            //desactiver le mouvement du perso
            ToggleControl();
            //lancer le joueur dans la meme direction que le projectile
            GetComponent<Rigidbody>().velocity = infoCollision.gameObject.GetComponent<Rigidbody>().velocity.normalized * forceColision;
            GetComponent<Rigidbody>().AddRelativeForce(0, 1f, 0);
            //activer le mouvement du perso
            Invoke("ToggleControl", .5f);
        }

        if (infoCollision.gameObject.tag == "enemi")
        {
            //tuer si cest laraignee rouge
            if (infoCollision.gameObject.name.Contains("spiderRed"))
            {
                Vie.hp -= 99999;
            }
            else //faire moins de degats si cest le vert
            {
                //baisser la barre de vie
                Vie.hp -= 20;
            }
        }
    }

    private void OnTriggerEnter(Collider infoCollision)
    {
        //ramasser fusil
        if (infoCollision.gameObject.name == "RiflePickup")
        {
            Destroy(infoCollision.gameObject);

            rifle1.SetActive(true);
            rifle2.SetActive(true);
            RifleScript.avoirFusil = true;
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
