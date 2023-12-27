using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlVaisseau : MonoBehaviour
{
    //deplacement vaisseau
    public float vitesse;
    public float vitesseTourne;
    public float vitesseMonte;

    Rigidbody rb;

    public GameObject[] lumieres;
    float progresMoteur;

    bool moteurEnMarche = false;
    public GameObject vaisseau;
    bool dansVaisseau;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //eteindre les lumieres du vaisseau
        foreach (var lumiere in lumieres)
        {
            lumiere.SetActive(false);
            lumiere.GetComponent<Light>().intensity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dansVaisseau = vaisseau.GetComponent<entrerVaisseau>().dansVaisseau;


        //allumer le moteur
        if (!moteurEnMarche) 
        {
            //allumer la gravite du vaiiseau
            GetComponent<Rigidbody>().useGravity = true;

            allumerMoteur();
            foreach (var lumiere in lumieres)
            {
                lumiere.SetActive(false);
                lumiere.GetComponent<Light>().intensity = 0;
            }
        }
        else
        {
            //eteindre la gravite du vaiiseau
            GetComponent<Rigidbody>().useGravity = false;

            //allumer lumieres
            foreach (var lumiere in lumieres)
            {
                lumiere.SetActive(true);
                if(lumiere.GetComponent<Light>().intensity < 6.5f)
                {
                    lumiere.GetComponent<Light>().intensity += 12f * Time.deltaTime;
                }
            }
        }

        //etteindre moteur
        if (!dansVaisseau)
        {
            moteurEnMarche = false;
        }
    }

    void FixedUpdate()
    {
        if (moteurEnMarche)
        {
            //tourner
            rb.AddRelativeTorque(Input.GetAxis("Vertical") * vitesseMonte, 0, Input.GetAxis("Horizontal") * -vitesseTourne);

            //avancer et reculer/freiner
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddRelativeForce(0, 0, vitesse);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                float vitesseRecule;
                if(rb.velocity.magnitude >= 0)
                {
                    vitesseRecule = vitesse / 3;
                }
                else
                {
                    vitesseRecule = vitesse * 100;
                }
                rb.AddRelativeForce(0, 0, -vitesseRecule);
            }
        }
    }

    void allumerMoteur()
    {
        if (Input.GetKey(KeyCode.E))
        {
            progresMoteur+= 300 * Time.deltaTime;
        }
        else if(progresMoteur > 0)
        {
            progresMoteur -= 150 * Time.deltaTime;
        }
        if (progresMoteur >= 100) { moteurEnMarche = true; }
    }
}
