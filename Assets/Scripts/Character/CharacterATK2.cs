using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterATK2 : MonoBehaviour
{

    public Animator animator;
    CharacterATK1 characterATK1;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterATK1 = FindObjectOfType<CharacterATK1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && characterATK1.getIsHit1Time())
        {
            handleATK2();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy"))
        {

        }
    }

    public void handleATK2()
    {

        animator.SetFloat("ATK2", 1);

        Invoke("resetATK1", 0.7f);
    }
    void resetATK1()
    {
        animator.SetFloat("ATK2", -1);
    }
}
