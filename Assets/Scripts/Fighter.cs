using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;

  protected Vector3 pushDirection;


  //   All fighter canr receive damage and die

  protected virtual void ReceiveDamage(Damage damage)
  {
    if (Time.time > lastImmune + immuneTime)
    {
      lastImmune = Time.time;
      hitpoint -= damage.damageAmount;
      pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;
            //   pushDirection += Vector3.up;
            //   pushDirection.Normalize();
            //   StartCoroutine(PushRecovery());

            GameManager.instance.ShowText(damage.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero * 20, 0.5f);
      if (hitpoint <= 0)
      {
        hitpoint = 0;
        Death();
      }
    }
  }

  protected virtual void Death()
  {
    // Destroy(gameObject);
  }
}
