using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Salud : MonoBehaviour
{
    //Variables
    public  int  salud;
    private int actualSalud;

    public UnityEvent AtDie;


    //Propiedad
    public int ActualSalud {
        get
        {
            return actualSalud;
        }
        set
        {

            actualSalud = (value > 0 && value <= salud) ? value : 0;

            if (value == 0 || value < 0)
            {
                actualSalud = 0;
                if (AtDie != null)
                {
                    AtDie.Invoke();
                    //Destroy(gameObject);
                }
            }
            if (value > salud)
            {
                actualSalud = salud;
            }
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        ActualSalud = salud;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateActualSalud(int amount)
    {
        ActualSalud += amount;
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
