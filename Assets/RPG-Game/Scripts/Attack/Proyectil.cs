using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Proyectil : MonoBehaviour
{
    public float InitialVelocity;
    public Vector2 InitialDirection;
    public int danger;
    public string ObjetiveTag;

    private Rigidbody2D myRgb2D;


    // Start is called before the first frame update
    void Start()
    {
        myRgb2D = GetComponent<Rigidbody2D>();
        myRgb2D.velocity = InitialDirection.normalized * InitialVelocity;

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ObjetiveTag))
        {
            other.gameObject.GetComponent<Attackable>().ReceiveAttack(danger, InitialDirection);
            Destroy(gameObject);
        }
    }
}
