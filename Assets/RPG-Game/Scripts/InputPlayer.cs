using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    //Propiedades
    public bool _skill1{get;private set;}          
    public bool _skill2{get;private set;}
    public bool _attack{get;private set;}
    public bool _inventory{get;private set;}
    public bool _catch{get;private set;}

    public float _horizontal{get;private set;}
    public float _vertical{get;private set;}

    //Inciar con la posicion Idle
    [HideInInspector]
    public Vector2 LookDirection = new Vector2(0,-1f);

    // Update is called once per frame
    void Update()
    {

        _attack = Input.GetButtonDown("Attack");
        _skill1 = Input.GetButtonDown("Skill1");
        _skill2 = Input.GetButtonDown("Skill2");
        _inventory = Input.GetButtonDown("Inventory");
        _catch = Input.GetButtonDown("Catch");
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        InputLookAtAttack();
        Debug.DrawLine(transform.position, transform.position + (Vector3)LookDirection.normalized * 3);
    }

    private void InputLookAtAttack()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            LookDirection.x = _horizontal;
            LookDirection.y = _vertical;
        }
    }
}
