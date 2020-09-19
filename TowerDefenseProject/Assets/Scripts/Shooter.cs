using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, projectileSpawn;

    // Start is called before the first frame update
    public void Fire()
    {
        Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
    }
}
