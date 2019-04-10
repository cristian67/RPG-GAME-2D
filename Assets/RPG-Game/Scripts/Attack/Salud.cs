using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    //Variables
    public int salud;

    private int actualSalud;

    //barras de salud - CAMBIANDO LA ESCLA - METODO DESCONTINUADO
    //public Transform saludBar;

    public Image saludBar;

    public UnityEvent AtDie;

    public int ModificatorSalud;

    //Propiedad para la salud
    public int mySalud { get { return salud + ModificatorSalud; } }


    //Propiedad
    public int ActualSalud {
        get
        {
            return actualSalud;
        }
        set
        {

            actualSalud = (value > 0 && value <= mySalud) ? value : 0;

            if (value == 0 || value < 0)
            { 
                actualSalud = 0;
                gameObject.layer = 11;
                if (AtDie != null)
                {
                    AtDie.Invoke();
                    //Destroy(gameObject);
                }
            }
            if (value > mySalud)
            {
                actualSalud = mySalud;
            }
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        ActualSalud = mySalud;
    }


    public void UpdateActualSalud(int amount)
    {
        ActualSalud += amount;
        
        UpdateSaludBar();
        
    }


    public void UpdateSaludBar()
    {
        //Castear el valor por que es un 'int' 
        //Vector3 scale       = new Vector3((float)actualSalud / salud, 1, 1);
        if (saludBar)
        {
            saludBar.fillAmount = (float)actualSalud / mySalud;
        }
    }


    public void ModifySaludBase(int amount)
    {
        salud += amount;
        UpdateSaludBar();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
