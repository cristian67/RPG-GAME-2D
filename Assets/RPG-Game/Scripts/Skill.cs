using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProyectilShoot( Proyectil proyectil, float velocity, Vector2 direction, int danger)
    {
        //Instanciar objeto
        Proyectil newProyectil = Instantiate(proyectil, (Vector2)transform.position, Quaternion.identity);

        //Opcion 1:
        //Almacenar proyectiles en el wizard o objeto que lanza el proyectil
        newProyectil.gameObject.transform.SetParent(transform);

        //Opcion 2:
        //Almacenar proyectiles en un objeto vacio en la escena
        //newProyectil.gameObject.transform.SetParent(GameManager.Instance.proyectilContainer);


        //Instanciar valores
        newProyectil.InitialVelocity  = velocity;
        newProyectil.InitialDirection = direction;
        newProyectil.danger           = danger;

        //angulo de rotacion
        float angleRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        newProyectil.transform.Rotate(0, 0, angleRotation);
    }


    public void Dash(Vector2 directionDash, Rigidbody2D rigidbody2D)
    {
        Vector2 velocityDirection = directionDash.normalized * 20;
        rigidbody2D.velocity = velocityDirection;
    }

}
