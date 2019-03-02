using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishedLevel : MonoBehaviour
{
    private Collider2D _collider2D;
    public UnityEvent onFinishedLevel; 

    private void Start(){

        _collider2D = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        //LevelManager.loadLevel();
        onFinishedLevel.Invoke();
    }
}
