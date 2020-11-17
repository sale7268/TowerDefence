using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  private Waypoints[] navPoints;
  private Transform target;
  private Vector3 direction;
  public float amplify = 1;
  private int index = 0;
  private bool move = true;
    float Starthealth = 100;
    float currentHealth;
    public Image healthbar;

    //Sounds
    public AudioSource impactSound;
    public AudioClip clip1;

    private void Start()
    {
        impactSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void StartEnemy(Waypoints[] navigationalPath)
  {
    currentHealth = Starthealth;
    navPoints = navigationalPath;
    //Place our enemy at the start point
    transform.position = navPoints[index].transform.position;
    NextWaypoint();
    
    //Move towards the next waypoint
    //Retarget to the following waypoint when we reach our current waypoint
    //Repeat through all of the waypoints until you reach the end
  }

  // Update is called once per frame
  void Update()
  {
    if (move)
    {
      transform.Translate(direction.normalized * Time.deltaTime * amplify);

      if ((this.transform.position - target.position).magnitude < .1f)
      {
        NextWaypoint();
      }
    }

  }

  private void NextWaypoint()
  {
    if (index < navPoints.Length - 1)
    {
      index += 1;
      target = navPoints[index].transform;
      direction = target.position - transform.position;
    }
    else
    {
      move = false;
    }
  }

    public void EnemyHit()
    {
        if(currentHealth <= 0)
        {
            Debug.Log(currentHealth);
            impactSound.clip = clip1;
            impactSound.Play();
            Destroy(this.gameObject);
        }
        currentHealth-=0.1f;
        healthbar.fillAmount = currentHealth / 100f;
        GameObject.Find("GameManager").GetComponent<GameManager>().EnemyHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            Debug.Log("Attacking tower");
            GameObject.Find("GameManager").GetComponent<GameManager>().TowerHit();
        }
    }

}
