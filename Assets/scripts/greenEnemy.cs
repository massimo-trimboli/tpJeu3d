using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenEnemy : MonoBehaviour
{
    //donnes pour le projectile
    public float vitesseBalle;
    public GameObject pew;
    GameObject target;

    int hp = 2;
    bool estMort = false;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        //pew.SetActive(false);
        InvokeRepeating("Tirrer", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!estMort)
        {
            transform.LookAt(target.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    void Tirrer()
    {
        GameObject balle = Instantiate(pew, pew.transform.position, pew.transform.rotation);
        balle.SetActive(true);
        //balle.transform.LookAt(target.transform);
        //balle.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, vitesseBalle);
        Vector3 direction = (target.transform.position - balle.transform.position).normalized;
        balle.GetComponent<Rigidbody>().AddForce(direction * vitesseBalle);
        
        GetComponent<Animator>().SetTrigger("tire");
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        //gerer la vie de lenemi
        if (infoCollision.gameObject.tag == "projectile")
        {
            hp--;

            if(hp <= 0)
            {
                if(!estMort)
                {
                    Vie.compteurEnemi--;
                    GetComponent<Animator>().SetTrigger("mort");
                    estMort = true;
                    CancelInvoke();
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
