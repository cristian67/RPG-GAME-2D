using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
   [HideInInspector] public bool _skill1{get;private set;}          
   [HideInInspector] public bool _skill2{get;private set;}
   [HideInInspector] public bool _attack{get;private set;}
   [HideInInspector] public bool _inventory{get;private set;}
   [HideInInspector] public bool _catch{get;private set;}

   [HideInInspector] public float _horizontal{get;private set;}
   [HideInInspector] public float _vertical{get;private set;}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _attack    = Input.GetButtonDown("Attack");
        _skill1    = Input.GetButtonDown("Skill1");
        _skill2    = Input.GetButtonDown("Skill2");
        _inventory = Input.GetButtonDown("Inventory");
        _catch     = Input.GetButtonDown("Catch");
        _horizontal= Input.GetAxis("Horizontal");
        _vertical  = Input.GetAxis("Vertical");

        
        
    }
}
