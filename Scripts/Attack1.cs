using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour

{
    private float timeBtwAttack;
    public float starTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator camAnim;
    public Animator playerAnim;
    public float attackRange;
    public int damage;

    // Update is called once per frame

    void Update()
    {

        if (starTimeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                //    for (int i = 0; i < enemiesToDamage.Length; i++)
                //    {
                //        enemiesToDamage[i].GetComponent<EneTree>().TakeDamage(damage);
                //    }
                //}
                timeBtwAttack = starTimeBtwAttack;
            }
            else
            {
                timeBtwAttack = Time.deltaTime;
            }
        }

        //attack range
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
}
