﻿using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class RedTriangleController : MonoBehaviour
{
    public float speed = 10.0f;
    private float angle;

    private Material material;

    public void Start()
    {
        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, Mathf.Sin(Mathf.PI / 3.0f), 0),
            new Vector3(1, 0, 0),
            new Vector3(-0.5f, -Mathf.Sin(Mathf.PI / 3.0f), 0),
        };

        mesh.triangles = new int[] { 0, 1, 2 };

        var meshRenderer = GetComponent<MeshRenderer>();
        material = new Material(meshRenderer.sharedMaterial);
        meshRenderer.material = material;
    }

    public void Update()
    {
        angle += Time.deltaTime * speed;
        var modelView = Matrix4x4.Rotate(Quaternion.Euler(0, 0, angle));
        material.SetMatrix("modelMatrix", modelView);
    }
}
