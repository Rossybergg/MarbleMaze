using UnityEngine;

public class gemPickup : MonoBehaviour {

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            other.GetComponent<PlayerPickups>().gems++;
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
