using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemyAI
{
    public Proyectil proyectil;

    protected override void EnemyAttack()
    {
        //base.EnemyAttack();
        Debug.Log("Shoot fire ball ! ");
        skill.ProyectilShoot(proyectil, proyectil.InitialVelocity, input.directionPlayer, attributes.attack);
    }

    protected override void FlipSprite()
    {
        _sprite.flipX = input.horizontal < 0 ? false : true;
    }

}
