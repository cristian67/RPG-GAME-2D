using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour, IPointerDownHandler
{

    public int amountStock;
    public Item itemStore;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (itemStore == null)
        {
            image.enabled = false;
        }
    }


    protected virtual void UsedObjectGrid()
    {
        if (itemStore)
        {
            if (itemStore.UsedItem())
            {
                ReduceStock(1);
            }
        }
    }

    public void ReduceStock(int amount)
    {
        amountStock-=amount;
        if (amountStock<=0)
        {
            DeleteObject();
        }
    }

    public  void AddObject(Item item, int amount)
    {
        itemStore = item;
        image.enabled = true;
        image.sprite  = item.artwork;
        amountStock = amount;
    }

    public virtual void DeleteObject()
    {

        Inventary.Instance.RemoveObject(itemStore);
        ResetGrid();
    }

    protected void ResetGrid()
    {
        image.sprite = null;
        amountStock = 0;
        image.enabled = false;
        itemStore = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UsedObjectGrid();
    }
}
