using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeStat : MonoBehaviour
{
    float HP;
    float damage;
    float moveSpeed;

    private void Start()
    {
        HP = 40;
        moveSpeed = 4;
        damage = 7;
    }

    public float getHP()
    {
        return HP;
    }
    public float getDamage()
    {
        return damage;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void getHitByPlayer(float dam)
    {
        HP -= dam;
    }
}
