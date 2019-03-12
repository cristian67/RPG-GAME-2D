using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Salud       mySalud;
    private Rigidbody2D myRgb2D;

    // Start is called before the first frame update
    void Start()
    {
        mySalud = GetComponent<Salud>();
        myRgb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveAttack(){

        //Debug.Log("Me golpeaste");
        mySalud.ActualSalud -= 1;
    }

    public void ReceiveAttack(int danger, Vector2 attackDirection)
    {
        mySalud.UpdateActualSalud(-danger);
        myRgb2D.AddForce(attackDirection * danger);

    }
}
