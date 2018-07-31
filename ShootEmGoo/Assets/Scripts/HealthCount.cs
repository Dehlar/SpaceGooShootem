using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCount : MonoBehaviour {

    public static int health;
    public TextMesh textAbove;

    void Start()
    {
        health = 3;
    }

    void Update()
    {
        for(int i=0; i<health; i++)
        {
            textAbove.text = health.ToString();
        }
    }
}
