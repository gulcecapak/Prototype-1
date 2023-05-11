using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private float verticalInput;
    private GameObject Propeller;
    // Start is called before the first frame update
    void Start()
    {
        Propeller = GameObject.Find("Propeller");
    }

    // Update is called once per frame
    void Update()
    {
        //set the propeller to rotate
        Propeller.transform.Rotate(Vector3.forward, 20.0f);


        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime * verticalInput);
    }
}
