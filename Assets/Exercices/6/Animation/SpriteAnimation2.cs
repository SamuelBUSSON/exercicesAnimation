using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SpriteAnimation2 : MonoBehaviour
{
    public SpritesheetDescription2 spritesheet;


    public string sprite;
    public string defaultAnimation;
    public float frameLength;
    public AnimationScenario scenario;

    private Queue<AnimationScenario.SequenceItem> sequence;
    private AnimationScenario.SequenceItem currentAction;
    private float elapsed;
    private string anim;
    private int frame = 0;
    private int frameSecond = 1;

    private float time;

    public void Start()
    {
        sequence = new Queue<AnimationScenario.SequenceItem>(scenario.sequence);
        anim = defaultAnimation;
    }

    public void Update()
    {
        if (sequence.Count > 0 && elapsed >= sequence.Peek().time)
        {
            currentAction = sequence.Dequeue();
        }

        elapsed += Time.deltaTime;
        time += Time.deltaTime;
        DoAction();

        float valTest = time / frameLength;
        if(valTest > 1)
        {
            valTest = 0.0f;
        }
            

        if (time >= frameLength)
        {
            frame++;
            frameSecond++;

            if (spritesheet.GetFrame(GetFrameName(frame)) == null)
            {
                frame = 0;
            }
            if (spritesheet.GetFrame(GetFrameName(frameSecond)) == null)
            {
                frameSecond = 0;
            }
            time = 0.0f;
        }
        var frameDesc = spritesheet.GetFrame(GetFrameName(frame));
        var frameDesc2 = spritesheet.GetFrame(GetFrameName(frameSecond));

        int[] rotate1 = frameDesc.rotated;
        int[] rotate2 = frameDesc2.rotated;
        int[] res = new int[rotate2.Length];

        for(int i = 0; i < rotate1.Length; i++)
        {
           // Debug.Log("R1 : " + rotate1[i] + " R2 : " + rotate2[i]);
            res[i] = Mathf.FloorToInt(Mathf.Lerp(rotate1[i], rotate2[i], valTest));
           // Debug.Log(res[i]);
        }
        //Debug.Log("<color=green>" + valTest + "</color>");
        //Debug.Log("");
        
        GetComponent<TentacleAnimation>().setRotated(res);

    }


    void DoAction()
    {
        if (currentAction.setAnim)
        {
            SetAnim(currentAction.newAnim);
        }      
    }

    string GetFrameName(int frameValue)
    {
        return string.Format("{0}/{1}/{2}", sprite, anim, frameValue);
    }

    void SetAnim(string newAnim)
    {
        if (anim == newAnim)
            return;

        anim = newAnim;
        frame = 0;
    }
}
