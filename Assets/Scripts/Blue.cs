using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;

    private Transform target;

    private void Awake()
    {
        transform.position = new Vector3(20.0f, 1.0f, 20.0f);

        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.localScale = new Vector3(0f, 1.0f, 0f);

        target = cylinder.transform;
        target.transform.position = new Vector3(0f, 1.0f, 0f);




    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target.position *= -1.0f;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

