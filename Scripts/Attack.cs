using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
   
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
        //if(Time.time >= nextAttackTime)
        //{
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ATK();
                //nextAttackTime= Time.time + 1f / attackRate;
            }
        //}
    }
        //    if(starTimeBtwAttack <= 0)
        //    {
        //        if (Input.GetKey(KeyCode.Space))
        //        {
        //           // camAnim.SetTrigger("shake");
        //            playerAnim.SetTrigger("attack");
        //            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        //            for(int i = 0; i < enemiesToDamage.Length; i++)
        //            {
        //                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        //            }
        //        }
        //        timeBtwAttack = starTimeBtwAttack;
        //    }
        //    else
        //    {
        //        timeBtwAttack = Time.deltaTime;
        //    }}
        
    void ATK()
    {
        playerAnim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
          enemy.GetComponent<theBoss>().TakeDamage(40);
        }
    }

    //attack range
    void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
