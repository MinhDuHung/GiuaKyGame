using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    float HP;
    float damage;
    float MP;
    float moveSpeed;
    float atkRange;

    private void Start()
    {
        HP = 200f;
        MP = 20f;
        moveSpeed = 7f;
        damage = 15f;
        atkRange = 2f;
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

    public float getMP()
    {
        return MP;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void getHitByEnermy(float dam)
    {
        HP -= dam;
    }

}
