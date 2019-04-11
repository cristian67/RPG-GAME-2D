using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactive : MonoBehaviour, IPointerDownHandler {

    public    UnityEvent OnInteractive;
    protected PlayerController player;
    protected BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();

        player = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    //// Update is called once per frame SOLO TESTEO
    //void Update()
    //{
    //    OnInteractive.Invoke();
    //}

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
        OnInteractive?.Invoke();
    }
}
