using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            float randomTime = Random.Range(1f, 5f);
            yield return new WaitForSeconds(randomTime);

            Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        }
    }

}
