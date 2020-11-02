using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOBJ : MonoBehaviour
{
    
    public Camera myCamera;
    public Transform towerParent;
    public GameObject tower;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 MousePosition = Input.mousePosition;

            Ray ray = myCamera.ScreenPointToRay(MousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("EasyEnemy"))
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().EnemyHit();
                    if(GameObject.Find("GameManager").GetComponent<GameManager>().EnemyHealth == 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
                if (hit.collider.CompareTag("TowerPosition"))
                {
                    if (GameObject.Find("GameManager").GetComponent<GameManager>().CoinCount >= 40)
                    {
                        Instantiate(tower, hit.transform.position, Quaternion.identity, towerParent);
                        GameObject.Find("GameManager").GetComponent<GameManager>().DefensePlaced();
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}