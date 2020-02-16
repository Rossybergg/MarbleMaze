
using UnityEngine;

public class gemSpin : MonoBehaviour {

public float spinX;
public float spinY;
public float spinZ;

    void Update()
    {
        transform.Rotate(spinX, spinY, spinZ);
    }
}
