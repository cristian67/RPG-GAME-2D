using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void loadLevel() {

        int _actualLevel = SceneManager.GetActiveScene().buildIndex;
        int _nexLevel    = ++_actualLevel;

        //Cargar escena
        SceneManager.LoadScene(_nexLevel);
    }
}
