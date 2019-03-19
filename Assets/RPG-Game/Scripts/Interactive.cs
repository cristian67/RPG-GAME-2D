using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactive : MonoBehaviour, IPointerDownHandler {

    private Collider2D myCollider;
    public  UnityEvent OnInteractive;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();

        player = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInteractive.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Click");
        ToInteract();
    }

    private void ToInteract()
    {
        foreach (RaycastHit2D interactive in player.Interact())
        {
            if (interactive.collider.gameObject == gameObject)
            {
                Interaction();
            }
        }
    }

    public virtual void Interaction()
    {
        Debug.Log("Interaccion "+ gameObject.name);
    }
}
