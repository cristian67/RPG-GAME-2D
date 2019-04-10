using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipamentPanel : MonoBehaviour
{
    public static EquipamentPanel Instance;

    public Attributes _attribute;
    public EquipamentGrid[] _equipamentGrids;

    public List<Kit> equipamentsList = new List<Kit>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _equipamentGrids = GetComponentsInChildren<EquipamentGrid>();
    }

    public Kit EquipmentObject(Kit equip)
    {
        foreach (EquipamentGrid gridEquip in _equipamentGrids)
        {
            if (equip.typeKit == gridEquip._typeKit)
            {
                //Casilla vacia
                if (!gridEquip.itemStore)
                {
                    Debug.Log("Casilla vacia");
                    AddEquip(equip, gridEquip);
                    return null;
                }
                //Casilla ocupada
                else
                {
                    Kit _equipamentObject = gridEquip.itemStore as Kit;
                    AddEquip(equip, gridEquip);
                    return _equipamentObject;
                }
            }
        }

        return null;
    }

    private void AddEquip(Kit equip, EquipamentGrid obj)
    {
        obj.AddObject(equip, 1);

        //Agregar a la lista
        equipamentsList.Add(equip);

        _attribute.UpdateEquip(equipamentsList);
    }

    //LLamarlo desde afuera tmbn
    public void RemoveEquip(Kit equip)
    {
        //Quitar de la lista el objecto equipo
        equipamentsList.Remove(equip);

        _attribute.UpdateEquip(equipamentsList);

    }

}
