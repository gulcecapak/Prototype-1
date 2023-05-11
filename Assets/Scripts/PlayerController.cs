using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    //[SerializeField] private float speed = 20.0f;
    [SerializeField] private float horsePower = 0;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Moves the car forward based on vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);   // globalı locale cevirdik unityde!
            //Turning the vehicle Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            //print speed
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // For kph, change 2.237 to 3.6 // Mathf.Round float hız değerinin ondalıklı gözükmesini engeliyor int e yuvarlıyor 
            speedometerText.SetText("Speed: " + speed + "mph");

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40); //round per minute yani dk daki devir sayısı (dönüş sayısı), % işareti mod hesaplar bölümden sonra kalanı bulmaya yarar Modulus/Remainder (%) operator
            rpmText.SetText("RPM: " + rpm);
        }

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}