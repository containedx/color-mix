using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    public Camera camera;

    public float lineThickness = 1f;

    private Mesh mesh;

    private Vector3 lastMousePosition;

    private void Update()
    {
        //Mouse Pressed
        if(Input.GetMouseButtonDown(0))
        {
            DrawSimpleSquareMesh();
        }

        //Mouse held down
        if (Input.GetMouseButton(0))
        {
            UpdateMesh();
            //transform.position = GetMouseWorldPosition();
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;
        return worldPos;
    }

    private void DrawSimpleSquareMesh()
    {
        mesh = new Mesh();

        lastMousePosition = GetMouseWorldPosition();
        transform.position = lastMousePosition;

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(-lineThickness, lineThickness);
        vertices[1] = new Vector3(-lineThickness, -lineThickness);
        vertices[2] = new Vector3(lineThickness, -lineThickness);
        vertices[3] = new Vector3(lineThickness, lineThickness);

        uv[0] = Vector2.zero;
        uv[1] = Vector2.zero;
        uv[2] = Vector2.zero;
        uv[3] = Vector2.zero;

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.MarkDynamic();

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void UpdateMesh()
    {
        Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
        Vector2[] uv = new Vector2[mesh.uv.Length + 2];
        int[] triangles = new int[mesh.triangles.Length + 6];

        mesh.vertices.CopyTo(vertices, 0);
        mesh.uv.CopyTo(uv, 0);
        mesh.triangles.CopyTo(triangles, 0);

        int vId = vertices.Length - 4;
        int vId0 = vId + 0;
        int vId1 = vId + 1;
        int vId2 = vId + 2;
        int vId3 = vId + 3;

        Vector3 currentMousePos = GetMouseWorldPosition();
        Vector3 mouseForwardVector = (currentMousePos - lastMousePosition).normalized;
        Vector3 normal2DVector = new Vector3(0, 0, -1f);

        Vector3 cross = Vector3.Cross(mouseForwardVector, normal2DVector) * lineThickness;
        Vector3 invertedCross = Vector3.Cross(mouseForwardVector, normal2DVector * -1f) * lineThickness;

        Vector3 newVertexUp = currentMousePos + cross;
        Vector3 newVertexDown = currentMousePos + invertedCross;

        vertices[vId2] = newVertexUp; 
        vertices[vId3] = newVertexDown;

        uv[vId2] = Vector2.zero;
        uv[vId3] = Vector2.zero;

        int tIndex = triangles.Length - 6;


        triangles[tIndex + 0] = vId0;
        triangles[tIndex + 1] = vId2;
        triangles[tIndex + 2] = vId1;
        triangles[tIndex + 3] = vId1;
        triangles[tIndex + 4] = vId2;
        triangles[tIndex + 5] = vId3;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        lastMousePosition = currentMousePos;
    }
}
