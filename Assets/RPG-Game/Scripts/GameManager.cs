using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform  playerSpawnPoint;
    public PlayerController player { get; private set; }

    //Singleton
    private static  GameManager instance;
    public  static  GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Instancia es null");
            }

            return instance;
        }
    }

    private void Awake(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.transform.position = playerSpawnPoint.position;
        instance = this;
        
    }

  
}
