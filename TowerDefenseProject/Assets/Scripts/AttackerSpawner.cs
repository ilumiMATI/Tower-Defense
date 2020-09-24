using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float minTimeToSpawn = 1f;
    [SerializeField] float maxTimeToSpawn = 5f;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            float randomTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            yield return new WaitForSeconds(randomTime);
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker spawnedAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        spawnedAttacker.transform.parent = transform;
    }

    public bool IsAttackerinLane()
    {
        return transform.childCount > 0;
    }
}
