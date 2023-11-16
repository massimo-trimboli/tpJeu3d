using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sciptBalle : MonoBehaviour
{
    private void OnCollisionEnter(Collision infoCollision)
    {
        Destroy(gameObject);
    }
}
