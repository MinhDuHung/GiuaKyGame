using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterATK1 : MonoBehaviour
{

    public Animator animator;
    public Animator flyingAnim;
    bool isHit1Time;
    FlyingEyeStat flyingEye;
    public Transform enermy;
    CharacterStat character;
    float attackRange = 2;
    void Start()
    {
        character = FindObjectOfType<CharacterStat>();
        flyingEye = FindObjectOfType<FlyingEyeStat>();
        animator = GetComponent<Animator>();
        isHit1Time = false;
        enermy = GameObject.FindGameObjectWithTag("Enermy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            handleATK1();
        }
    }


    public void handleATK1()
    {

        animator.SetFloat("ATK1", 1);
        if (Vector2.Distance(transform.position, enermy.position) <= attackRange && enermy != null)
        {
            flyingEye.getHitByPlayer(character.getDamage());
            flyingAnim.SetBool("takeHit", true);
            if (flyingEye.getHP() <= 0) {
                Destroy(flyingEye.gameObject);
                animator.SetFloat("ATK1", -1);
            } 
            isHit1Time = true;
        }
        Invoke("resetATK1", 0.5f);

    }
    void resetATK1()
    {
        flyingAnim.SetBool("takeHit", false);
        animator.SetFloat("ATK1", -1);
        isHit1Time = false;
    }

    public bool getIsHit1Time()
    {
        return isHit1Time;
    }
}

