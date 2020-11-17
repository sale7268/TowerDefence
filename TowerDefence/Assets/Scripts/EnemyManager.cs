using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Group
{
    public GameObject enemyType;
    [Range(0,50)] public int amountOfEnemies;
    [Range(0,5)]  public float timeDelay;

    public Group(GameObject enemyType, int amountOfEnemies, float timeDelay)
    {
        this.enemyType = enemyType;
        this.amountOfEnemies = amountOfEnemies;
        this.timeDelay = timeDelay;
    }
}

[System.Serializable]
public struct Wave
{
    public Group[] enemyGroups;
}


public class EnemyManager : MonoBehaviour
{
    public Waypoints[] navPoints;
    public Wave enemyWave;

    private void Start()
    {
        SpawnWave();

    }

    private void SpawnWave()
    {
        foreach(Group group in enemyWave.enemyGroups)
        {
            StartCoroutine(SpawnGroup(group));
        }
    }

    IEnumerator SpawnGroup(Group enemyGroup)
    {
        int i = 0;
        while(enemyGroup.amountOfEnemies > 0)
        {
            GameObject spawnedEnemy = Instantiate(enemyGroup.enemyType);
            spawnedEnemy.GetComponent<Enemy>().StartEnemy(navPoints);
            spawnedEnemy.name = $"{enemyGroup.enemyType.ToString()} {i}";
            enemyGroup.amountOfEnemies--;
            i++;
            yield return new WaitForSeconds(enemyGroup.timeDelay);
        }
    }

}
