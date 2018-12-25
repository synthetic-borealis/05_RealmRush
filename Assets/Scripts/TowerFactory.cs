using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towersParentTransform;

    private Queue<Tower> towerQueue = new Queue<Tower>();

    // create an empty queue of towers

    public void AddTower(Waypoint baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numberOfTowers = towers.Length; // change to queue size

        if (numberOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        Tower tower = towerQueue.Dequeue();
        tower.baseWaypoint.isPlaceable = true;
        baseWaypoint.isPlaceable = false;
        tower.baseWaypoint = baseWaypoint;
        tower.transform.position = tower.baseWaypoint.transform.position;
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        tower.baseWaypoint = baseWaypoint;
        tower.transform.parent = towersParentTransform;
        towerQueue.Enqueue(tower);
    }
}
