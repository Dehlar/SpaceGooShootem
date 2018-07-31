using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 4f;
    public float speed = 2f;

    public GameObject Player;
    public GameObject blob;

    private float distance;

    Transform target;

    private void Start()
    {
        target = Player.transform;
    }

    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        GoToPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void GoToPlayer()
    {
        if (distance <= lookRadius)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
}
