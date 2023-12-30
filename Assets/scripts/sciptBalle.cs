using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sciptBalle : MonoBehaviour
{
    void Start()
    {
        //detruire projectile apres 1s
        Invoke("Detruire", 5f);
    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        Destroy(gameObject);
    }

   void Detruire()
    {
        Destroy(gameObject);
    }
}
