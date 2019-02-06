using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Rigidbody2D rgb2D;
    private Transform _transform;

    [SerializeField]
    private float _velocity;

    // Start is called before the first frame update
    void Start()
    {
        inputPlayer = GetComponent<InputPlayer>();
        _transform  = GetComponent<Transform>();
        rgb2D       = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 

        //Movement
        Vector2 _VelocityVector = new Vector2(inputPlayer._horizontal, inputPlayer._vertical) * _velocity;
        //rgb2D.AddForce(force);
        rgb2D.velocity = _VelocityVector;
    }
}
