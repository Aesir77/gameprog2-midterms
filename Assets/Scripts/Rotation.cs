using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public string Enemy;
    public float ARange = 5f;
    public Transform target;
    public Transform parttoRotate;
    public float turnspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject Enemy in Enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                nearestDistance = distanceToEnemy;
                nearestEnemy = Enemy;

            }
        }
        if (nearestEnemy != null && nearestDistance <= ARange)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;

        }
    }
    private void Update()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(parttoRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;

        parttoRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, ARange);

    }

    
}



