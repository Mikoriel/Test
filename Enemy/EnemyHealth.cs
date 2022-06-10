using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5;
    private int Health;

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    private void Start()
    {
        Health = maxHealth;
    }

    public bool IsAllive()
    {
        return Health > 0 ? true : false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;

        if(Health <= 0)
        {
            animator.SetTrigger("ZombieDes");
        }
    }

}
