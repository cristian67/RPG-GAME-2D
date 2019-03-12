using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    private Transform  player;


    public Vector2 directionPlayer       { get; private set; }
    public float   vertical              { get { return directionPlayer.y; } }
    public float   horizontal            { get { return directionPlayer.x; } }
    public float   distancePlayer        { get { return directionPlayer.magnitude; } }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
        DefinedDirectionToPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        DefinedDirectionToPlayer();
    }


    private void DefinedDirectionToPlayer()
    {
        directionPlayer = player.position - transform.position;
    }

}
