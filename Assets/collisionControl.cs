using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        print("landed on floor");
    }
  
}
