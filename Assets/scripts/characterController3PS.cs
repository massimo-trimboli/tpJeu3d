using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController3PS : MonoBehaviour
{
    public float vitesse = 15;
    public float hauteurSaut = 40;
    public float sensitiviteSourisX = 222f;
    public float sensitiviteSourisY = 250f;

    public static float hauteurAuSol = 2.25f;

    public GameObject cam;

    //float pour garder la rotation de la cemera
    float camRotate;

    Rigidbody rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }



    void Update()
    {
        //tourner
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitiviteSourisX * Time.deltaTime, 0);

        camRotate += -Input.GetAxis("Mouse Y") * sensitiviteSourisY * Time.deltaTime;
        camRotate = Mathf.Clamp(camRotate, -80, 80);
        cam.transform.localEulerAngles = new Vector3(camRotate, 0, 0);


        //deplacement
        float deplacementX = Input.GetAxis("Horizontal") * vitesse;
        float deplacementZ = Input.GetAxis("Vertical") * vitesse;
        float deplacementY;

        //saut
        Debug.DrawRay(transform.position, -transform.up);

        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, hauteurAuSol))
        {
            deplacementY = hauteurSaut;
        }
        else
        {
            deplacementY = rb.velocity.y;
        }

        rb.velocity = transform.forward * deplacementZ + transform.right * deplacementX + transform.up * deplacementY;
    }
}
