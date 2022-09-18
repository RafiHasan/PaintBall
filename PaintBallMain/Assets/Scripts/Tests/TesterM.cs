using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TesterM : MonoBehaviour
{

    Mesh mesh;
    private void Awake()
    {
        mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        DefinePolygon(vertices, uv, triangles);

        GenerateMesh(vertices, uv, triangles);

        GetComponent<MeshFilter>().mesh = mesh;


    }

    private void GenerateMesh(Vector3[] vertices, Vector2[] uv, int[] triangles)
    {
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.MarkDynamic();
    }

    private static void DefinePolygon(Vector3[] vertices, Vector2[] uv, int[] triangles)
    {
        vertices[0] = new Vector3(-1, +1);
        vertices[1] = new Vector3(-1, -1);
        vertices[2] = new Vector3(+1, -1);
        vertices[3] = new Vector3(+1, +1);

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
    }

    private void Start()
    {
        
        
    }

    private void Update()
    {
        transform.position = MousePosition.GetMouseWorldPosition();
    }

    
}
