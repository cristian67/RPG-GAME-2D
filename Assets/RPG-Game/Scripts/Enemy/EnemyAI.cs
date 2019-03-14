using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Salud))]
[RequireComponent(typeof(InputEnemy))]
public class EnemyAI : Enemy
{
    protected InputEnemy input;
    protected SpriteRenderer _sprite;
    protected Skill skill;

    private Attacker attacker;
    private bool death;
    private bool attack;
    private bool inCombat;
    private Animator _anim;
    private Vector2 attackDirection;


    [SerializeField] private float detentionDistance;
    [SerializeField] private float attackDistance;


    //Hash Animation
    private int walkHash;
    private int attackHash;
    private int deathHash;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputEnemy>();
        attacker = GetComponent<Attacker>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        skill = GetComponent<Skill>();

        walkHash   = Animator.StringToHash("isWalk");
        attackHash = Animator.StringToHash("Attack");
        deathHash  = Animator.StringToHash("Death");

        //Instanciar Puff
        Instantiate(puff, transform);

    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }

    protected void Behavior()
    {
        if (!death)
        {
            if (!attack && input.distancePlayer < attackDistance)
            {
                AttackToPlayer();

            }

            else if (!attack && (inCombat || input.distancePlayer < detentionDistance))
            {
                MoveToPlayer();
            }
        }
    }

    private void AttackToPlayer()
    {
        int attackProbability = Random.Range(0, 100);
        _anim.SetBool(walkHash, false);

        if (attackProbability > 97)
        {
            attackDirection = input.directionPlayer;
            attack = true;
            inCombat = true;
            _anim.SetTrigger(attackHash);
        }


    }

    void MoveToPlayer()
    {
        _anim.SetBool(walkHash, true);
        FlipSprite();
        transform.position += (Vector3)input.directionPlayer * attributes.velocity * Time.deltaTime;
    }

    protected virtual void FlipSprite()
    {
        _sprite.flipX = input.horizontal < 0 ? true : false;
    }

    protected virtual void EnemyAttack()
    {
        attacker.Attack(attackDirection, attributes.attack);
        attack = false;
    }

    void SetAttackingFalse()
    {
        attack = false;
    }


    public void Death()
    {
        death = true;
        _anim.SetBool(deathHash, true);
    }
}
