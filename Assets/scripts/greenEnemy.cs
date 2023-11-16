using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenEnemy : MonoBehaviour
{
    //donnes pour le projectile
    public float vitesseBalle;
    public GameObject pew;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        //pew.SetActive(false);
        InvokeRepeating("Tirrer", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void Tirrer()
    {
        GameObject balle = Instantiate(pew, pew.transform.position, pew.transform.rotation);
        balle.SetActive(true);
        //balle.transform.LookAt(target.transform);
        //balle.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, vitesseBalle);
        balle.GetComponent<Rigidbody>().AddForce((target.transform.position - balle.transform.position) * vitesseBalle);
        
        GetComponent<Animator>().SetTrigger("tire");
    }
}
