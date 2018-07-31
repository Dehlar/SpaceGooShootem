using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEnemies : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
