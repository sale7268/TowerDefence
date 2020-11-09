using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EasyEnemy"))
        {
            Debug.Log("Got hit");
            GameObject.Find("GameManager").GetComponent<GameManager>().TowerHit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EasyEnemy"))
        {
            Debug.Log("Got hit");
            GameObject.Find("GameManager").GetComponent<GameManager>().TowerHit();
        }
    }
}
