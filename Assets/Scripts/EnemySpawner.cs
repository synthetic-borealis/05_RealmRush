using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawning = 5f;
    [SerializeField] Transform deathFXParentTransform;
    [SerializeField] Text spawnedEnemies;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // loop forever
        {
            AddScore();
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            newEnemy.GetComponent<EnemyDamage>().deathFXParentTransform = deathFXParentTransform;
            newEnemy.GetComponent<EnemyMovement>().deathFXParentTransform = deathFXParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
