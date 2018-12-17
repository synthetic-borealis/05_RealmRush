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
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, collisionMesh.transform.position, Quaternion.identity);
        // todo Add explosion sound
        Destroy(gameObject);
    }
}
