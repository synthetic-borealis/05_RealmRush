using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] ParticleSystem hitParticles;
    public Transform deathFXParentTransform;
    [SerializeField] AudioClip enemyHitSFX;
    public AudioClip enemyDeathSFX;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        audioSource.PlayOneShot(enemyHitSFX);
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
        ParticleSystem fx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParentTransform;
        fx.Play();

        Destroy(fx.gameObject, fx.main.duration);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        // destroy particle after delay
        Destroy(gameObject);
    }
}
