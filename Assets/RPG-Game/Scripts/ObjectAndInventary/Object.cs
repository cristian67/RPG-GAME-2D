using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class Object : Interactive
{

    public Item item;
    private SpriteRenderer spriteRenderer;
    public int cantidad = 1;


    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.name = item.name;
        spriteRenderer.sprite = item.artwork;
    }

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameManager.Instance.player.GetComponent<PlayerController>();
        spriteRenderer.sortingLayerName = "Drop";
        myCollider.isTrigger = true;
        myCollider.size = new Vector2(1, 1);
        gameObject.layer = 12;
    }

    public override void Interaction()
    {
        if (Inventary.Instance.AddObject(item,cantidad))
        {
            Destroy(gameObject);
        }
    }
}
