using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticles;
    public Transform deathFXParentTransform;
    //[SerializeField] AudioClip enemySelfDestructSFX;

    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        ParticleSystem fx = Instantiate(goalParticles, transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParentTransform;
        fx.Play();
        Destroy(fx.gameObject, fx.main.duration);
        // todo Add explosion sound

        // destroy particle after delay
        Destroy(gameObject);
    }
}
