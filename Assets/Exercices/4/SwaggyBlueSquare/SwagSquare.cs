using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class SwagSquare: MonoBehaviour
{
    public float speed = 10.0f;

    private float translate = 0.0f;
    private bool test;
    private Material material;

    private float time = 0.0f;

    public void Start()
    {
        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        
        mesh.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0)
        };

        mesh.triangles = new int[] { 2, 1, 0, 3, 1, 2};

        Vector2[] uvs = new Vector2[mesh.vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(mesh.vertices[i].x, mesh.vertices[i].y);
            Debug.Log(mesh.vertices[i].x + " " + mesh.vertices[i].y);
        }

        mesh.uv = uvs;

        var meshRenderer = GetComponent<MeshRenderer>();
        material = new Material(meshRenderer.sharedMaterial);
        meshRenderer.material = material;

    }

    public void Update()
    {
        translate += test ? -0.01f : 0.01f;
        if(translate > 1f)
        {
            test = true;
        }
        if (translate < -1f)
        {
            test = false;
        }
        var modelView = Matrix4x4.Translate(new Vector3(translate, 0, 0));
        material.SetMatrix("modelMatrix", modelView);

        time += Time.deltaTime;
        material.SetFloat("_Time", time);

    }
}
