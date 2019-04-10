using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(menuName = "ObjetosEscriptables/Items/ItemGenerico")]
public class Item : ScriptableObject
{
    public Sprite artwork;
    public string name;
    public bool stackear; //Potions,etc;
    [TextArea(1, 3)]
    public string description;

    public virtual bool UsedItem()
    {
        Debug.Log("UTILIZANDO" + name);
        return true;
    }
}
