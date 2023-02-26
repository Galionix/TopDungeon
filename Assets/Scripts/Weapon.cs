using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collideable
{
    // damage structure
    public int damagePoint = 1;
    public float pushForce = 2f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing

    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
        // spriteRenderer.enabled = !spriteRenderer.enabled;
        // Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        // foreach (Collider2D coll in hits)
        // {
        //     if (coll.tag == "Enemy")
        //     {
        //         coll.GetComponent<Enemy>().Damage(damagePoint);
        //         Vector3 pushDir = (coll.transform.position - transform.position).normalized;
        //         pushDir += Vector3.up;
        //         coll.GetComponent<Rigidbody2D>().AddForce(pushDir * pushForce, ForceMode2D.Impulse);
        //     }
        // }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

                Damage dmg = new Damage {
                    origin = transform.position,
                    damageAmount = damagePoint,
                    pushForce = pushForce
                };

                coll.SendMessage("ReceiveDamage", dmg);

            Debug.Log(coll.name);
        }
        // if (coll.tag == "Enemy")
        // {
        //     coll.GetComponent<Enemy>().Damage(damagePoint);
        //     Vector3 pushDir = (coll.transform.position - transform.position).normalized;
        //     pushDir += Vector3.up;
        //     coll.GetComponent<Rigidbody2D>().AddForce(pushDir * pushForce, ForceMode2D.Impulse);
        // }
    }
}
