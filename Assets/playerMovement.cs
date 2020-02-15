using UnityEngine;

public class playerMovement : MonoBehaviour {

    public Rigidbody body;

    public float forwardForce = 2000f;
    public float movementForce = 500f;
    public float jumpForce = 1000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add forward force to player
       // body.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("w") ) {
            body.AddForce(0, 0, forwardForce * Time.deltaTime);
        };

        if ( Input.GetKey("s") ) {
            body.AddForce(0, 0, -forwardForce * Time.deltaTime);
        };


        if ( Input.GetKey("d") ) {
            body.AddForce( movementForce * Time.deltaTime , 0, 0);
        };

        if ( Input.GetKey("a") ) {
            body.AddForce( -movementForce * Time.deltaTime , 0, 0);
        };

        if ( Input.GetKey("space") ) {
            body.AddForce( 0 , jumpForce * Time.deltaTime , 0);
        };
    }
    

}
