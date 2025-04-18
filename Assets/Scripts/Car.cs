using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // Speed of the car
    [SerializeField]
    private float turnSpeed = 100f; // Speed of turning the car
    [SerializeField]
    private float brakeForce = 10f; // Force applied when braking
    [SerializeField]
    private GameObject[] brakeEffects; // Array of brake effect GameObjects
    private float turnInput; // Input for turning the car
    private float moveInput; // Input for moving the car

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the car
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrows)
        turnInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrows)
        MoveCar();
        TurnCar(); // Call the method to turn the car
        if (Input.GetKey(KeyCode.Space) && moveInput > 0) // Check if the space key is pressed for braking
        {
            Brake(); // Call the method to brake the car
        }
    }

    public void MoveCar()
    {
        rb.AddRelativeForce(moveInput * speed * Vector3.forward); // Move the car forward or backward based on input

        foreach (GameObject effect in brakeEffects)
        {
            effect.SetActive(false); // Activate the brake effect GameObjects
        }
    }

    public void TurnCar()
    {
        Quaternion re = Quaternion.Euler(Time.deltaTime * turnInput * turnSpeed * Vector3.up); // Calculate the rotation based on input

        rb.MoveRotation(rb.rotation * re); // Apply the rotation to the car's Rigidbody
    }

    public void Brake()
    {
        if (rb.linearVelocity.z != 0)
        {
            rb.AddRelativeForce(-Vector3.forward * brakeForce); // Apply a force in the opposite direction of the car's velocity to simulate braking

            foreach (GameObject effect in brakeEffects)
            {
                effect.SetActive(true); // Activate the brake effect GameObjects
            }
        }
    }
}
