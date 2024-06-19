using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int attack = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var healthBase = collision.gameObject.GetComponent<HealthBase>();
            healthBase.Damage(attack);
        }
    }
}
