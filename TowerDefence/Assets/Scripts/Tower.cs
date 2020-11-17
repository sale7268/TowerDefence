using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Enemy> CurrentEnemies;
    public Enemy currentTarget;
    public GameObject turret;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (currentTarget)
        {
            lineRenderer.SetPosition(0, turret.transform.position);
            lineRenderer.SetPosition(1, currentTarget.transform.position);
            currentTarget.GetComponent<Enemy>().EnemyHit();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Enemy newEnemy = collision.GetComponent<Enemy>();
        CurrentEnemies.Add(newEnemy);
        EvaluateTarget(newEnemy);
    }

    void OnTriggerExit(Collider collision)
    {
        Enemy enemyLeaving = collision.GetComponent<Enemy>();
        CurrentEnemies.Remove(enemyLeaving);
        EvaluateTarget(enemyLeaving);
        
    }

    private void EvaluateTarget(Enemy newEnemy)
    {
        if (currentTarget == newEnemy)
        {
            currentTarget = null;
            lineRenderer.enabled = false;
        }

        if(currentTarget == null)
        {
            currentTarget = CurrentEnemies[0];
            lineRenderer.enabled = true;
        }
    }

}
