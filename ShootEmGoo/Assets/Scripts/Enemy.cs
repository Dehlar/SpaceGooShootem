using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody rb;

    public GameObject enemy, explosion, heart, shield, bullet;

    public float xSpeed;
    public float ySpeed;

    public float speed;
    public bool canShoot;
    public float fireRate;
    public float health;
    public float bulletSpeed;

    // float randValue = Random.value;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        }

    void Update () {
        rb.velocity = new Vector3(xSpeed*-1,ySpeed);
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Controller>().Damage();
            Die();
        }
        if (col.gameObject.tag == "Bullets")
        {
            Damage();
        }
        if (col.gameObject.tag == "End")
        {
            Destroy(enemy);
        }
    }

    void Damage()
    {
        health--;
        if (health == 0)
        {
            Die();
            ScoreCounter.scoreValue++;
        }
    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Drop();
        Destroy(enemy);

    }

    private void Drop()
    {
        float rand = Random.value;
        if (rand < .30f) // 45% of the time
        {
            Instantiate(heart, transform.position, heart.transform.rotation);
        }
        else if (rand < .5f) // 45% of the time
        {
            Instantiate(shield, transform.position, shield.transform.rotation);
        }
    }

    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody tempRigidBodyBullet = temp.GetComponent<Rigidbody>();
        tempRigidBodyBullet.velocity = new Vector3(-bulletSpeed, 0);
    }
}
