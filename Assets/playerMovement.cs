using UnityEngine;

public class playerMovement : MonoBehaviour {

    public Rigidbody body;

    public float forwardSpeed = 500f;

    public float speed;

    public float strafeSpeed = 500f;
    public float jumpForce = 1000f;

    public float boostSpeed = 5000f;
    public bool marbleOnGround = true;

    public bool marbleOnSlope = false;

    public bool marbleOnBoostPad = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerControl();

    }


    void playerControl() {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if ( Input.GetKey("space") && marbleOnGround ) {
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
        } else {
            body.AddForce(0, 0, 0);
        }
    } 

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Ground" ) {
                marbleOnGround = true;
                marbleOnSlope = false;
                marbleOnBoostPad = false;
            }

            if ( collision.gameObject.tag == "BoostPad" ) {
                marbleOnGround = true;
                marbleOnSlope = false;
                marbleOnBoostPad = true;
            }

            if ( collision.gameObject.name == "Slope" ) {
                marbleOnSlope= true;
            }

    }

}
