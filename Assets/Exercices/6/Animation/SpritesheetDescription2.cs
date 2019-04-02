using System;
using System.Collections.Generic;
using UnityEngine;
using Json = MiniJSON.Json;

[CreateAssetMenu(fileName = "Spritesheet", menuName = "ScriptableObjects/2D Anim/Spritesheet", order = 1)]
public class SpritesheetDescription2 : ScriptableObject
{
    public TextAsset descriptionFile;
    public Texture2D texture;


    public class SpriteDescr
    {
        public int[] rotated;

        public SpriteDescr(Dictionary<string, object> descr, Texture2D texture)
        {
            var frameDesc = descr["rotated"] as Dictionary<string, object>;

            rotated = new int[5];

            rotated[0] = Convert.ToInt32(frameDesc["0"]);
            rotated[1] = Convert.ToInt32(frameDesc["1"]);
            rotated[2] = Convert.ToInt32(frameDesc["2"]);
            rotated[3] = Convert.ToInt32(frameDesc["3"]);
            rotated[4] = Convert.ToInt32(frameDesc["4"]);


        }
    }

    private readonly Dictionary<string, SpriteDescr> sprites = new Dictionary<string, SpriteDescr>();

    public void OnEnable()
    {
        if (descriptionFile == null)
            return;

        var descr = Json.Deserialize(descriptionFile.text) as Dictionary<string, object>;
        var frames = descr["frames"] as Dictionary<string, object>;
        foreach (var entry in frames)
        {
            sprites.Add(entry.Key, new SpriteDescr(entry.Value as Dictionary<string, object>, texture));
        }
    }

    public SpriteDescr GetFrame(string id)
    {
        SpriteDescr val;
        sprites.TryGetValue(id, out val);
        return val;
    }
}
