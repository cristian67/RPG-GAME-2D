using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Rigidbody2D rgb2D;
    private Transform _transform;

    //Movimiento
    private Animator _anim;
    private bool _isBack;
    private SpriteRenderer _sprite;
    int RunHashCode;

    [SerializeField]
    private float _velocity;

    // Start is called before the first frame update
    void Start()
    {
        inputPlayer = GetComponent<InputPlayer>();
        _transform  = GetComponent<Transform>();
        rgb2D       = GetComponent<Rigidbody2D>();
        _anim       = GetComponent<Animator>();
        _sprite     = GetComponent<SpriteRenderer>();
        RunHashCode = Animator.StringToHash("IsRun");
    }
    
    void FixedUpdate()
    {
        //Movement
        Vector2 _VelocityVector = new Vector2(inputPlayer._horizontal, inputPlayer._vertical) * _velocity;
        rgb2D.velocity = _VelocityVector;
    }

    void Update()
    {

        SplitSprite();

        //Movimiento Vertical y horizontal
        if (inputPlayer._horizontal != 0 || inputPlayer._vertical != 0)
        {
            SetXYAnimator();
            _anim.SetBool(RunHashCode, true);
        }
        else
        {
            _anim.SetBool(RunHashCode, false);
        }

    }

    private void SetXYAnimator()
    {
        _anim.SetFloat("X", inputPlayer._horizontal);
        _anim.SetFloat("Y", inputPlayer._vertical);
    }

    private void SplitSprite()
    {
        // Flip del sprite
        if (inputPlayer._horizontal > 0 && Mathf.Abs(inputPlayer._vertical) < Mathf.Abs(inputPlayer._horizontal))
        {
            _sprite.flipX = true;
        }
        else if (inputPlayer._horizontal != 0)
        {
            _sprite.flipX = false;
        }
    }

  
}
