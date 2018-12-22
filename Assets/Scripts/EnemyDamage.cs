using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem hitParticles;

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
        hitParticles.Play();
    }

    private void KillEnemy()
    {
        ParticleSystem fx = Instantiate(deathFX, collisionMesh.transform.position, Quaternion.identity);
        fx.Play();
        // todo Add explosion sound
        Destroy(gameObject);
    }
}
