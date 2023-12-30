using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class redEnemy : MonoBehaviour
{
    //variables de deplacement
    public float vitesseMax;
    public float acceleration;
    public float vitesse;

    GameObject target;
    Rigidbody rb;

    int hp = 3;
    bool estMort = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!estMort)
        {
            //aller vers le joeur sil est proche
            if (target != null)
            {
                //faire face au joueur
                transform.LookAt(target.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                //determiner la direction vers le joueur
                Vector3 direction = target.transform.position - transform.position;
                direction.Normalize();

                //se deplacer vers le joueur
                if (vitesse < vitesseMax)
                {
                    vitesse += acceleration * Time.deltaTime;
                }
                rb.velocity = new Vector3((direction * vitesse).x, rb.velocity.y, (direction * vitesse).z);
            }
            else
            {
                vitesse = 0;
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

            //animer si marche
            GetComponent<Animator>().SetFloat("vitesse", rb.velocity.magnitude);
        }
    }

    //cibler le jouer quand ill es proche
    void OnTriggerEnter(Collider infoCollision)
    {
        if (infoCollision.gameObject.tag == "Player")
        {
            target = infoCollision.gameObject;
        }
    }
    void OnTriggerExit(Collider infoCollision)
    {
        if (infoCollision.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        //gerer la vie de lenemi
        if (infoCollision.gameObject.tag == "projectile")
        {
            hp--;

            if (hp <= 0)
            {
                if (!estMort)
                {
                    Vie.compteurEnemi--;
                    GetComponent<Animator>().SetTrigger("mort");
                    estMort = true;
                    Invoke("Detruire", 5f);
                    GetComponent<AudioSource>().enabled = false;
                }
            }
        }
    }

    void Detruire()
    {
        Destroy(gameObject);
    }
}
