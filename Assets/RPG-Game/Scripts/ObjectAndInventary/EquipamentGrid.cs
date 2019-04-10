using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipamentGrid : Grid
{
    public Equipment _typeKit;

    protected override void UsedObjectGrid()
    {
        RemoveEquipment();
    }

    private void RemoveEquipment()
    {
        if (Inventary.Instance.inventaryFull)
        {
            Debug.Log("Inventario lleno");
        }

        else
        {
            if(Inventary.Instance.AddObject(itemStore, 1))
                DeleteObject();
        }

    }

    public override void DeleteObject()
    {
        EquipamentPanel.Instance.RemoveEquip((Kit)itemStore);
        ResetGrid();
    }
}
