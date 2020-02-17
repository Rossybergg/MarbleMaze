using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destryOverTime : MonoBehaviour
{
    public float lifeTime;
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
