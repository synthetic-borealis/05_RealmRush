using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject gun;

    private bool isFiring = true;

	// Update is called once per frame
	void Update()
    {
        objectToPan.LookAt(targetEnemy);
        ProcessFiring();
	}

    private void ProcessFiring()
    {
        ParticleSystem.EmissionModule gunEmmision = gun.GetComponent<ParticleSystem>().emission;

        gunEmmision.enabled = isFiring;
    }
}
