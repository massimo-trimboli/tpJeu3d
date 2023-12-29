using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class entrerVaisseau : MonoBehaviour
{
    public GameObject joueur;
    public GameObject camCockpit;
    public GameObject cam3rdPerson;

    public bool dansVaisseau = false;
    GameObject currentCam;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        currentCam = camCockpit;
    }

    // Update is called once per frame
    void Update()
    {
        //gestion cameras
        if (dansVaisseau && Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentCam = camCockpit;
            currentCam.SetActive(true);
            cam3rdPerson.SetActive(false);
        }
        if (dansVaisseau && Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentCam = cam3rdPerson;
            currentCam.SetActive(true);
            camCockpit.SetActive(false);
        }

        //sortir du vaisseau
        if (dansVaisseau && Input.GetKeyDown(KeyCode.F))
        {
            dansVaisseau = false;
            currentCam.SetActive(false);
            joueur.transform.parent = null;
            joueur.SetActive(true);

            //ajuster rotation du joueur
            joueur.transform.localEulerAngles = new Vector3(0, joueur.transform.localEulerAngles.y, 0);
        }
    }

    //entrer dans le vaisseau
    private void OnTriggerStay(Collider infoCollision)
    {
        if (infoCollision.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !dansVaisseau)
        {
            //metre en delais sur le changement de la booleene
            //dansVaisseau = true;
            Invoke("entrerDansVaisseau", 0.1f);
            joueur.transform.parent = transform;
            joueur.SetActive(false);
            currentCam.SetActive(true);
        }
    }

    void entrerDansVaisseau()
    {
        dansVaisseau = true;
    }
}
