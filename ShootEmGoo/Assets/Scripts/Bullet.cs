using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public int bulletCount;
    public GameObject bullet;

    //AudioSource bulletAudio;

    List<GameObject> bulletList;

    private void Start()
    {
        bulletSpeed = 50;
        bulletCount = 10;
        bulletList = new List<GameObject>();
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }

        //bulletAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 1.5f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }

    void Fire()
    {

        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.velocity = new Vector3(bulletSpeed, 0);
                break;
            }
        }

        //Play Audio
        //bulletAudio.Play();

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
}
