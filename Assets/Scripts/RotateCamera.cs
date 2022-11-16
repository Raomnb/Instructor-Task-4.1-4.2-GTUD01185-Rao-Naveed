using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //set horizontal axis as horizontal input so left right keys can be used to rotate camera
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime); // rotates the camera by pressing left and right keys

    }
}
