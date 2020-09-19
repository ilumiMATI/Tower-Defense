using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
}
