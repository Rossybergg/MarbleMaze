using UnityEngine;

public class gemPickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            other.GetComponent<PlayerPickups>().gems++;
            Destroy(gameObject);
        }
    }
}
