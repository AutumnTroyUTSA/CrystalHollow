using UnityEngine;

public class BoundaryVisualizer : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private void OnDrawGizmos()
    {
        // Set the color for the Gizmos lines
        Gizmos.color = Color.red;

        // Draw lines to represent the boundaries
        Vector3 minCorner = new Vector3(minX, minY, 0f);
        Vector3 maxCorner = new Vector3(maxX, maxY, 0f);

        // Draw lines to form a rectangular boundary
        Gizmos.DrawLine(new Vector3(minX, minY, 10f), new Vector3(maxX, minY, 10f));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0f), new Vector3(maxX, maxY, 0f));
        Gizmos.DrawLine(new Vector3(maxX, maxY, 0f), new Vector3(minX, maxY, 0f));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0f), new Vector3(minX, minY, 0f));
    
    }
}