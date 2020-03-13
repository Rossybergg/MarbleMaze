using UnityEngine;

public class playerMovement : MonoBehaviour {

    public Rigidbody body;
    public GameObject fallEffect;

    public float forwardSpeed = 500f;

    public float speed;

    public float strafeSpeed = 500f;
    public float jumpForce = 1000f;

    public float boostSpeed = 5000f;
    public float jumpPadSpeed = 5000f;
    public bool marbleOnGround = true;
    public bool marbleOnJumpPad = false;
    public bool marbleOnSlope = false;
    public bool marbleOnBoostPad = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerControl();

    }


    void playerControl() {

        if (marbleOnGround) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
            Vector3 relativeMovement = Camera.main.transform.TransformVector(movement);
            body.AddForce (relativeMovement * speed * Time.deltaTime);
        }


        if ( Input.GetButton("Jump") && marbleOnGround ) {
            body.AddForce( 0 , jumpForce * Time.deltaTime , 0, ForceMode.Impulse);
            marbleOnGround = false;
        };

        if ( marbleOnSlope ) {
            body.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        } else {
            body.AddForce(0, 0, 0);
        }

        if ( marbleOnBoostPad ) {
            body.AddForce(0, 0, boostSpeed * Time.deltaTime);
        }

        if ( marbleOnJumpPad ) {
            body.AddForce( 0 , 0 , 0);
            body.AddForce( 0 , jumpPadSpeed * Time.deltaTime , 0, ForceMode.Impulse);
            marbleOnJumpPad = false;
        }
    } 

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Ground" ) {
                marbleOnGround = true;
                marbleOnSlope = false;
                marbleOnBoostPad = false;
                    
                    if (body.velocity.y > 12 ) {
                        Instantiate(fallEffect, transform.position, transform.rotation);
                    }

            }

            if ( collision.gameObject.tag == "BoostPad" ) {
                marbleOnGround = true;
                marbleOnSlope = false;
                marbleOnBoostPad = true;
            }
            if ( collision.gameObject.tag == "JumpPad" ) {
                marbleOnGround = true;
                marbleOnJumpPad = true;
            }

            if ( collision.gameObject.name == "Slope" ) {
                marbleOnSlope= true;
            }



    }

}
