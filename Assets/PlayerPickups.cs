using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    public bool hasSuperJump = false;
    public bool hasSuperBoost = false;

    public float superJumpSpeed = 5000f;
    public float superBoostSpeed = 5000f;

    public Rigidbody body;
   private void OnCollisionEnter(Collision collision) {
        
        string pickup = collision.gameObject.tag;

        switch (pickup) {
            case "SuperJump":
                hasSuperJump = true;
                print("picked up Super Jump!");
                break;
            case "SuperBoost":
                hasSuperBoost = true;
                print("picked up Super Boost!");
                break;
            default:
                break;
        }
        
    }

    void FixedUpdate() {
        if ( Input.GetKey("v") && hasSuperJump ) {
            body.AddForce( 0 , superJumpSpeed * Time.deltaTime , 0, ForceMode.Impulse);
            hasSuperJump = false;
        }

        if ( Input.GetKey("c") && hasSuperBoost ) {
            body.AddRelativeForce(0, 0, superBoostSpeed * Time.deltaTime, ForceMode.Impulse);
            hasSuperBoost = false;
        }
    }
}
