using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMusiqueMenu : MonoBehaviour
{
    static GameObject musique;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        musique = gameObject;
    }
    //fonction appele au debut du jeu
    public static void arreterMusique()
    {
        Destroy(musique);
    }
}
