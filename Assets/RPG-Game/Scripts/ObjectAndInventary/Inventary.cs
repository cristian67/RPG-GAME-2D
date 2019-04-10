using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{

    public bool inventaryFull;


    public static Inventary Instance;


    private Grid[] grids;

    private List<Item> objets = new List<Item>();
    private int emptyGrid = 0;

    private void Awake()
    {
        Instance = this;
        grids = GetComponentsInChildren<Grid>();
    }


    void DetermineNextEmptyGrid()
    {
        emptyGrid = 0;
        foreach (Grid grid in grids)
        {
            if (grid.itemStore)
            {
                emptyGrid++;
            }
            else
            {
                break;
            }
        }
        if (emptyGrid>=grids.Length)
        {
            inventaryFull = true;
        }
    }

    public bool AddObject(Item item, int amount)
    {
        DetermineNextEmptyGrid();

        if ((item.stackear && !objets.Contains(item) && !inventaryFull) || (!item.stackear && !inventaryFull))
        {

            //objecto apilable y no se tiene una copia
            Grid addGrid = grids[emptyGrid];

            objets.Add(item);
            addGrid.AddObject(item, amount);
            return true;
        }

        else if (item.stackear && objets.Contains(item))
        {
            //objeto apilable y se tiene una copia
            for (int i = 0; i < grids.Length; i++)
            {
                if (item == grids[i].itemStore)
                {
                    grids[i].amountStock += amount;
                    break;
                }
            }

            return true;
        }

        else
        {
            Debug.Log("Inventario lleno");
            return false;
        }
    }

    public void RemoveObject(Item item)
    {
        objets.Remove(item);
    }
}
