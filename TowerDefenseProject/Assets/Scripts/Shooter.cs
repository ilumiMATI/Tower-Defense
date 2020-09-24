using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, projectileSpawn;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        // if it is my lane then do shoot animation
        if(myLaneSpawner.IsAttackerinLane())
        {
            animator.SetBool("isAttacking", true);
        }
        // if not then idle animation
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }
    }

    public void Fire()
    {
        Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
    }
}
