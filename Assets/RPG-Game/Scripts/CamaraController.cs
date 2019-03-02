using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;
    //public GameObject player;

    private void Start() {

        cv = GetComponent<CinemachineVirtualCamera>();
        //METODO QUE CONSUME MUCHO
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        cv.m_Follow = player;
    }
}
