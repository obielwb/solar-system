using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRing : MonoBehaviour
{
    [Range(3, 360)]
    public int segments = 3; 
    public float innerRadius = 0.7f;
    public float thickness = 0.5f;
    public Material ringMaterial; 


    MeshFilter ringMeshFilter; 
    GameObject ring; 
    Mesh ringMesh; 
    MeshRenderer ringMeshRenderer; 

    void Start()
    {
        ring = new GameObject(name + " Ring");
        ring.transform.parent = transform; 
        ring.transform.localScale = Vector3.one; 
        ring.transform.localPosition = Vector3.zero; 
        ring.transform.localRotation = Quaternion.identity; 

        ringMeshFilter = ring.AddComponent<MeshFilter>(); 
        ringMesh = ringMeshFilter.mesh; 
        ringMeshRenderer = ring.AddComponent<MeshRenderer>(); 
        ringMeshRenderer.material = ringMaterial; 

        // Criar ring mesh 
        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2];
        int[] triangles = new int[segments * 6 * 2];
        Vector2[] uv = new Vector2[(segments + 1) * 4];
        
        int halfway = (segments + 1) * 2; 

        for (int i = 0; i < segments + 1; i++) {
            float progress = (float) i / (float) segments;
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius + thickness);
            vertices[i * 2] = vertices[i * 2 + halfway] =  new Vector3(x, 0f, z) * innerRadius;

            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f);

            if (i != segments) {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1; 

                triangles[i * 12 + 6] = i * 2  + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] =  i * 2 + 1;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway; 
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway; 
            } 
        }

        ringMesh.vertices = vertices; 
        ringMesh.triangles = triangles; 
        ringMesh.uv = uv; 
        ringMesh.RecalculateNormals();
    }
}