using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class commencerJeu : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("intro");
    }
}
