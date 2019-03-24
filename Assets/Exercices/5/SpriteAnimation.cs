using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(RawImage))]
public class SpriteAnimation : MonoBehaviour
{
    public SpritesheetDescription spritesheet;
    public string sprite;
    public string defaultAnimation;
    public float frameLength;
    public AnimationScenario scenario;

    private Queue<AnimationScenario.SequenceItem> sequence;
    private AnimationScenario.SequenceItem currentAction;
    private float elapsed;
    private string anim;
    private int frame;

    private float time;

    private RectTransform rectTransform;
    private RawImage image;
    private Texture2D spritesheetTexture;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<RawImage>();
        spritesheetTexture = image.texture as Texture2D;

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

        float width = spritesheetTexture.width;
        float height = spritesheetTexture.height;

        if(time >= frameLength)
        {
            frame++;
            if (spritesheet.GetFrame(GetFrameName()) == null)
            {
                frame = 0;
            }
            time = 0.0f;
        }

        var frameDesc = spritesheet.GetFrame(GetFrameName());

        float x = frameDesc.frame.x / width;
        float y = frameDesc.frame.y / height;

        float x2 = frameDesc.frame.width / width;
        float y2 = frameDesc.frame.height / height;


        rectTransform.pivot = frameDesc.pivot;
        rectTransform.sizeDelta = frameDesc.sourceSize;

        image.uvRect = new Rect(x, y, x2, y2);
    }


    void DoAction()
    {
        if (currentAction.setAnim)
        {
            SetAnim(currentAction.newAnim);
        }

        rectTransform.anchoredPosition += currentAction.motion * Time.deltaTime;
    }

    string GetFrameName()
    {
        return string.Format("{0}/{1}/{2}", sprite, anim, frame);
    }

    void SetAnim(string newAnim)
    {
        if (anim == newAnim)
            return;

        anim = newAnim;
        frame = 0;
    }
}
