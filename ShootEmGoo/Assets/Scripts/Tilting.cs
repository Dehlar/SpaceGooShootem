using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tilting : NetworkBehaviour {
    [SerializeField]
    float horizontalRotationVariable = 2.0f;
    [SerializeField]
    Vector3 newTtransform;

    public GameObject GO;

    void Start()
    {
        newTtransform = GO.transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                newTtransform.x += Input.GetAxis("Vertical") * horizontalRotationVariable;

                if (newTtransform.x > 45.0f)
                {
                    newTtransform.x = 45.0f;
                }

                if (newTtransform.x < -45.0f)
                {
                    newTtransform.x = -45.0f;
                }
            }
            else
            {
                newTtransform.x /= 1.1f;
            }

            GO.transform.rotation = Quaternion.Euler(newTtransform);
        }
    }
}
