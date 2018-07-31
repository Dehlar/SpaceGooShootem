using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDespawner : MonoBehaviour {

    public GameObject explosion;

	void Start () {
        Destroy(gameObject, 6f);
	}

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

}
