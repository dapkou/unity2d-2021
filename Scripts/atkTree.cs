using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkTree : MonoBehaviour

{
    private float timeBtwAttack;
    public float starTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator camAnim;
    public Animator playerAnim;
    public float attackRange;
    //
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ATK();
        }
    }
    void ATK()
    {
        playerAnim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<theTree>().TakeDamage(40);
        }
    }

    //attack range
    void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;
        
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
