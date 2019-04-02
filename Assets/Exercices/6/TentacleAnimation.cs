using UnityEngine;

[RequireComponent(typeof(TentacleSkeleton))]
public class TentacleAnimation : MonoBehaviour
{
    public int[] rotations;

    private TentacleSkeleton skeleton;

    public void Start()
    {
        skeleton = GetComponent<TentacleSkeleton>();
    }

    public void Update()
    {
        for (int i = 0; i < rotations.Length; i++)
        {
            skeleton.SetRotation(i, Quaternion.Euler(0f, 0f, rotations[i]));
        }
    }

    public void setRotated(int[] new_rotate)
    {
        rotations = new_rotate;
    }
}
