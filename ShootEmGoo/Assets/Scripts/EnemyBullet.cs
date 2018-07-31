using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Controller>().Damage();
            Die();
        }
        if (col.gameObject.tag == "Bullets")
        {
            Die();
        }
        if(col.gameObject.tag == "End")
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
