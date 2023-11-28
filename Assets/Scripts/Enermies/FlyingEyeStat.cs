using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeStat : MonoBehaviour
{
    float HP;
    float damage;
    float moveSpeed;
    float atkRange;
    private void Start()
    {
        HP = 40f;
        moveSpeed = 4f;
        damage = 7f;
        atkRange = 1.5f;
    }

    public float getHP()
    {
        return HP;
    }
    public float getDamage()
    {
        return damage;
    }
    public float getATKRange()
    {
        return atkRange;
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
