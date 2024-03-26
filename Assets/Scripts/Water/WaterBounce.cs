using UnityEngine;

public class WaterBounce : MonoBehaviour
{
    public float waterSurfaceY = 0f; // Y-coordinate of the water surface
    public float bounceForce = 10f; // Force applied to make the object bounce

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the object is below the water surface
        if (transform.position.y < waterSurfaceY)
        {
            // Make the object bounce
            Vector3 bounceDirection = Vector3.up;
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}