using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] float damage = 100f;

    // reference
    Rigidbody2D theRigidBody2D;
    private void Start()
    {
        theRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // rick's movement
        //transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        theRigidBody2D.MovePosition((Vector2)transform.position + Vector2.right * projectileSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker collidedAttacker = otherCollider.GetComponent<Attacker>();
        Health attackerHealth = otherCollider.GetComponent<Health>();

        if (collidedAttacker && attackerHealth)
        {
            attackerHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
