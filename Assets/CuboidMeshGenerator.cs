using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CuboidMeshGenerator : MonoBehaviour
{
    public float height = 1.5f;
    public float width = 3.5f;
    public float length = 8f * 12f;
    public bool pivotOnCenter = true;

    void Start()
    {
        CreateCuboidMesh(height, width, length);
    }

    // Creates a cuboid mesh without sharing vertices, so that different
    // normals can be calculated orthogonal to plane of face.  This gives
    // sharp edges, as opposed to the cuboids with 8 vertices, shared across
    // all faces.     
    private void CreateCuboidMesh(float height, float width, float length)
    {
        // 3 sets of same vertices, so that each face using that same logical
        // vertex can use separate copy. Needed for normals
        Vector3[] vertices = {
            new Vector3 (0, 0, 0),
            new Vector3 (width, 0, 0),
            new Vector3 (width, height, 0),
            new Vector3 (0, height, 0),
            new Vector3 (0, height, length),
            new Vector3 (width, height, length),
            new Vector3 (width, 0, length),
            new Vector3 (0, 0, length),

            new Vector3 (0, 0, 0),
            new Vector3 (width, 0, 0),
            new Vector3 (width, height, 0),
            new Vector3 (0, height, 0),
            new Vector3 (0, height, length),
            new Vector3 (width, height, length),
            new Vector3 (width, 0, length),
            new Vector3 (0, 0, length),

            new Vector3 (0, 0, 0),
            new Vector3 (width, 0, 0),
            new Vector3 (width, height, 0),
            new Vector3 (0, height, 0),
            new Vector3 (0, height, length),
            new Vector3 (width, height, length),
            new Vector3 (width, 0, length),
            new Vector3 (0, 0, length)
        };

        if (pivotOnCenter)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] -= new Vector3(.5f * width, .5f * height, .5f * length);
            }
        }

        int[] triangles = {
            0, 2, 1, //face front
            0, 3, 2,
            10, 11, 4, //face top
            10, 4, 5,
            9, 18, 13, //face right
            9, 13, 6,
            8, 7, 12, //face left
            8, 12, 19,
            21, 20, 15, //face back
            21, 15, 14,
            16, 22, 23, //face bottom
            16, 17, 22
        };

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            if (mesh != null)
            {
                //Debug.Log("Recalculated mesh");
                mesh.Clear();
                mesh.vertices = vertices;
                mesh.triangles = triangles;
                mesh.RecalculateNormals();
            }
        }
    }

}
