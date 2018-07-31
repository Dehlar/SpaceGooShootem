using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

    [SerializeField]
    public Rigidbody rb;
    [SerializeField]
    public float speed;
    [SerializeField]
    public GameObject ship, explosion, shield;
    [SerializeField]
    public int health = 3;

    [SerializeField]
    private bool shieldOn = false;

    private void Awake()
    {
        rb.GetComponent<Rigidbody>();
    }

	void Update () {
        if (isLocalPlayer)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0));
            rb.AddForce(new Vector3(0, Input.GetAxis("Vertical") * speed));
        }

        HealthCount.health = health;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Shield")
        {
            Destroy(col.gameObject);
            shieldOn = true;
            shield.SetActive(true);
            Debug.Log("shielded");
        }
        if (col.gameObject.tag == "Heart")
        {
            Destroy(col.gameObject);
            health++;
        }
        if (col.gameObject.tag == "Top and Bottom")
        {
            Damage();
        }
    }

    public void Damage()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!shieldOn)
        {
            health--;
            if (health == 0)
            {
                CmdRequestDeath();
            }
        } else
        {
            shield.SetActive(false);
            shieldOn = false;
        }
    }

    /*void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/

    [Command]
    void CmdRequestDeath()
    {
        RpcDeath();
    }

    [ClientRpc]
    void RpcDeath()
    {
        if (isLocalPlayer)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
