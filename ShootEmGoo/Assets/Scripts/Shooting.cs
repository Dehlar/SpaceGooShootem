using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour
{
    [SerializeField]
    public float bulletSpeed = 20;
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public int bulletCount = 10;
    [SerializeField]
    public GameObject bulletspot;

    [SerializeField]
    AudioSource bulletAudio;
    [SerializeField]
    List<GameObject> bulletList;

    void Start()
    {

        bulletList = new List<GameObject>();
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }

        bulletAudio = GetComponent<AudioSource>();

    }

    /*void Fire()
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

    }*/

    void Update()
    {
        if (!isLocalPlayer)
        { return; }
            if (Input.GetMouseButtonDown(0))
        {
          CmdFire();
        }
    }

    [Command]
    void CmdFire()
    {
        RpcFire();
    }

    [ClientRpc]
    void RpcFire()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = bulletspot.transform.position;
                bulletList[i].transform.rotation = bulletspot.transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.velocity = new Vector3(bulletSpeed, 0);
                break;
            }
        }

        //Play Audio
        bulletAudio.Play();
    }

}
