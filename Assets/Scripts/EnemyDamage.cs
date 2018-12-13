using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] GameObject deathFX;

    private void Start()
    {
        //AddNonTriggerCollider();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("Current hitpoints are " + hitPoints);
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, collisionMesh.transform.position, Quaternion.identity);
        // todo Add explosion sound
        Destroy(gameObject);
    }
}
