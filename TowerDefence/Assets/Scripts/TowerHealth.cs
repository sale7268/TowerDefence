using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EasyEnemy 1(Clone)")
        {
            Debug.Log("Got hit");
            GameObject.Find("GameManager").GetComponent<GameManager>().TowerHit();
        }
    }
}
