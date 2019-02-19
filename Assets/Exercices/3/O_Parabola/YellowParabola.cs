using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class YellowParabola : MonoBehaviour
{
    public float speed = 10.0f;
    private float angle;
    private float time = 0.0f;

    public int[] Tris = new int[100];

    private Material material;

    public void Start()
    {
        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float count = 5f;
        float x = -count;

        int countTriangle = 0;

        int valCount = 30;

        Vector3[] listPoint = new Vector3[2*valCount + 3];
        int[] listPointsIndex = new int[6*valCount + 6];

        for (int i = 0; i <= 2*valCount; i+=2)
        {

            listPoint[i] = new Vector3(i, 0, 0);
            listPoint[i+1] = new Vector3(i, (count * count) +(-x*x), 0);

            x +=  2.5f*count / valCount;

            if(i%2 == 0 && i >= 4)
            {
                
                listPointsIndex[countTriangle] = i - 3;
                listPointsIndex[countTriangle+1] = i - 2;
                listPointsIndex[countTriangle+2] = i - 4;
                listPointsIndex[countTriangle+3] = i - 1;
                listPointsIndex[countTriangle+4] = i - 2;
                listPointsIndex[countTriangle+5] = i - 3;

                countTriangle += 6;
            }            
        }

        mesh.vertices = listPoint;
        mesh.triangles = listPointsIndex;

        var meshRenderer = GetComponent<MeshRenderer>();
        material = new Material(meshRenderer.sharedMaterial);
        meshRenderer.material = material;
    }

    public void Update()
    {
        var modelView = Matrix4x4.TRS(new Vector3(-3, -3, 0), Quaternion.Euler(0, 0, 0), new Vector3(0.2f, 0.2f, 0.2f));
        material.SetMatrix("modelMatrix", modelView);

        time += Time.deltaTime;
        GetComponent<MeshRenderer>().material.SetFloat("_Oscill", time);
    }
}
