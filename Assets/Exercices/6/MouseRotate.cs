using UnityEngine;

public class MouseRotate : MonoBehaviour
{

    public Transform basePosition;

    public void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 basePos = basePosition.position;
        basePos.y += (mousePosition.y < basePos.y) ? 1.0f : +1.0f;

        float angle = Vector2.SignedAngle(basePos, mousePosition);

        //Debug.Log("<color=green>" + angle + "</color>");

        TentacleAnimation ta =  GetComponent<TentacleAnimation>();

        float angleTest = angle / ta.rotations.Length;

        for (int i = 0; i <= ta.rotations.Length - 1; i++)
        {
            ta.rotations[i] = (int)(1.5*angleTest);
        }

       // Debug.Log(string.Format("World: {0}, Angle {1}", mousePosition, angle));
    }
}
