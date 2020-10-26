using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOBJ : MonoBehaviour
{
    RaycastHit hit;

    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
                if(hit.collider.gameObject.name == "EasyEnemy")
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().EnemyHit();
                    if(GameObject.Find("GameManager").GetComponent<GameManager>().EnemyHealth == 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                Debug.DrawLine(Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
            }
        }
    }
}