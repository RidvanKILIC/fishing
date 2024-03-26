using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public Transform poleStartPoint;
    public Transform poleEndPoint;
    public Transform lure;
    public int poleSegments = 2;
    public int lineSegments = 10;
    public float poleWidth = 0.1f;
    public float lineWidth = 0.05f;
    public Material poleMaterial;
    public Material lineMaterial;

    private LineRenderer poleRenderer;
    private LineRenderer lineRenderer;

    [SerializeField] float throwForce;
    private void Awake()
    {
        //// Create fishing pole
        //poleRenderer = CreateLineRenderer(poleMaterial, poleWidth, poleSegments);
        // Create fishing line
        lineRenderer = CreateLineRenderer(lineMaterial, lineWidth, lineSegments);

        // Position the lure at the end of the fishing line
        if (lure != null)
            lure.position = poleEndPoint.position;
    }
    void Start()
    {
        

        UpdateRod();
    }

    void Update()
    {
        UpdateRod();
        if (Input.GetKeyDown(KeyCode.E))
            throwRod();
    }

    void UpdateRod()
    {
        if (poleStartPoint == null || poleEndPoint == null)
            return;

        //// Update fishing pole
        //poleRenderer.SetPosition(0, poleStartPoint.position);
        //poleRenderer.SetPosition(1, poleEndPoint.position);

        // Update fishing line
        Vector3[] linePositions = new Vector3[lineSegments + 1];
        for (int i = 0; i <= lineSegments; i++)
        {
            float t = (float)i / lineSegments;
            linePositions[i] = Vector3.Lerp(poleStartPoint.position, poleEndPoint.position, t);
            // Apply gravity to each line segment
            linePositions[i] += Physics.gravity * t * t * 0.005f;
        }
        lineRenderer.SetPositions(linePositions);
    }

    LineRenderer CreateLineRenderer(Material material, float width, int segments)
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.material = material;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        return lineRenderer;
    }
    public void throwRod()
    {
        poleEndPoint.GetComponent<Rigidbody>().useGravity = true;
        poleEndPoint.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * throwForce , ForceMode.Impulse);
    }
}
