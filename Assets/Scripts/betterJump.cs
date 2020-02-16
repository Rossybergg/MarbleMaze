using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterJump : MonoBehaviour
{
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplyer = 2f;

  Rigidbody rigidBody;

  void Awake() {
    rigidBody = GetComponent<Rigidbody> ();  
  }

  void FixedUpdate() {
      if ( rigidBody.velocity.y < -5 ) {
          rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
      }
  }
}
