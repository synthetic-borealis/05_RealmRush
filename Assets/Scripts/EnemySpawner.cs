using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawning = 5f;
    [SerializeField] Transform deathFXParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // loop forever
        {
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            newEnemy.GetComponent<EnemyDamage>().deathFXParentTransform = deathFXParentTransform;
            newEnemy.GetComponent<EnemyMovement>().deathFXParentTransform = deathFXParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }
}
