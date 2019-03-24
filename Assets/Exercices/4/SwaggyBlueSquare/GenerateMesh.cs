using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GenerateMesh: MonoBehaviour
{
    public float speed = 10.0f;

    private float translate = 0.0f;
    private float rotateValue = 0.0f;
    private bool test;
    private Material material;

    public int xSize, ySize;

    private float time = 0.0f;
    private Mesh mesh;
    private Vector3[] vertices;

    private void Awake()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        material = new Material(meshRenderer.sharedMaterial);
        meshRenderer.material = material;
        Generate();

    }

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                vertices[i] = new Vector3(x, y);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
        mesh.triangles = triangles;
    }

    public void Update()
    {
        translate += test ? -0.01f : 0.01f;

        if (translate > 1f)
        {
            test = true;
        }
        if (translate < -1f)
        {
            test = false;
        }
        Quaternion rotate;
        var translateVector = new Vector3(translate, 0, 0);
        
        rotate = Quaternion.Euler(translate * 45 , 60, translate * 10);

        var scale = new Vector3(0.05f, 0.05f, 0.05f);

        var modelView = Matrix4x4.TRS(translateVector, rotate, scale);
        material.SetMatrix("modelMatrix", modelView);

        material.SetFloat("time", Time.time);

    }
}
