using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    private int numberOfTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (numberOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
            numberOfTowers++;
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private static void MoveExistingTower(Waypoint baseWaypoint)
    {
        print("Can`t place more towers!");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}
