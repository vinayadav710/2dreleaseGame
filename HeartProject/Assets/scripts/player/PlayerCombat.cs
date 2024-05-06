using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public float attackRate = 2f;
    float nextAttacktime = 0f;

    public int attackDamage = 20; 

    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttacktime)
         {   if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttacktime = Time.time + 1f / attackRate;
            }
         }  
    }

    public void Attack()
    {
        //Play an attack Animation
        //Detect enemies in the range
        //Damage them
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
       Gizmos.DrawWireSphere(attackPoint.position , attackRange);
    }
}
