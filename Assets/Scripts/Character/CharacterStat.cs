using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    float HP;
    float damage;
    float MP;
    float moveSpeed;

    private void Start()
    {
        HP = 100;
        MP = 20;
        moveSpeed = 7;
        damage = 15;
    }

    public float getHP()
    {
        return HP;
    }
    public float getDamage()
    {
        return damage;
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
