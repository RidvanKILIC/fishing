using UnityEngine;

public class whaleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the ship's movement
    public float rotationSpeed = 100f; // Speed of the ship's rotation
    public float driftFactor = 0.95f; // Factor by which velocity decreases when no input is applied
    public float maxAngularVelocity = 10f; // Maximum angular velocity to prevent oversteering
    public float rotationInputThreshold = 0.1f; // Threshold for rotation input
    [SerializeField] Windbutton_Controller verticalInp;
    [SerializeField] SteeringWheel horizontalInp;
    private Rigidbody rb;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Freeze rotation around X and Z axes
        rb.maxAngularVelocity = maxAngularVelocity; // Set maximum angular velocity
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float moveInput = verticalInp.getValue();
        //Debug.Log("Horizontal: " + horizontalInp.getValue());
        // Rotate the ship left/right based on input
        float rotateInput = horizontalInp.getValue();
        if (canMove)
        {
            Vector3 movement = transform.forward * moveInput * moveSpeed;
            // Move the ship forward/backward based on input
            if(Mathf.Abs(moveInput)>0.1f)
                rb.AddForce(movement, ForceMode.Force);


            Vector3 torque = Vector3.up * rotateInput * rotationSpeed;

            if (Mathf.Abs(rotateInput) > rotationInputThreshold)
            {
                rb.AddTorque(torque, ForceMode.Force);
            }
           

        }
        if (moveInput == 0f && rotateInput == 0f)
        {
            // Apply drift when no input is applied
            ApplyDrift();
        }

    }
    void ApplyDrift()
    {
        // Reduce velocity gradually to simulate drift
        rb.velocity *= driftFactor;
    }
    public void setCanMove(bool _state)
    {
        canMove = _state;
    }

}
