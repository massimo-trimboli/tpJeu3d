using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlVaisseau : MonoBehaviour
{
    public GameObject[] lumieres;
    float progresMoteur;

    bool moteurEnMarche = false;
    public GameObject vaisseau;
    bool dansVaisseau;




    // Start is called before the first frame update
    void Start()
    {
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
            allumerMoteur();
            foreach (var lumiere in lumieres)
            {
                lumiere.SetActive(false);
                lumiere.GetComponent<Light>().intensity = 0;
            }
        }
        else
        {
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

    void allumerMoteur()
    {
        if (Input.GetKey(KeyCode.Space))
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
