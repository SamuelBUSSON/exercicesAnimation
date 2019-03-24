using System;
using System.Collections.Generic;
using UnityEngine;
using Json = MiniJSON.Json;

[CreateAssetMenu(fileName = "Spritesheet", menuName = "ScriptableObjects/2D Anim/Spritesheet", order = 1)]
public class SpritesheetDescription : ScriptableObject
{
    public TextAsset descriptionFile;
    public Texture2D texture;

    public class SpriteDescr
    {
        public RectInt frame;
        public Vector2Int sourceSize;
        public Vector2 pivot;

        public SpriteDescr(Dictionary<string, object> descr, Texture2D texture)
        {
            var frameDesc = descr["frame"] as Dictionary<string, object>;
            var sourceSizeDesc = descr["sourceSize"] as Dictionary<string, object>;
            var pivotDesc = descr["pivot"] as Dictionary<string, object>;

            frame = new RectInt(
                Convert.ToInt32(frameDesc["x"]),
                Convert.ToInt32(frameDesc["y"]),
                Convert.ToInt32(frameDesc["w"]),
                Convert.ToInt32(frameDesc["h"])
            );

            // L'axe Y de la texture est inversé par rapport aux données de la sprite sheet
            frame.y = texture.height - frame.yMax;

            sourceSize = new Vector2Int(Convert.ToInt32(sourceSizeDesc["w"]), Convert.ToInt32(sourceSizeDesc["h"]));
            pivot = new Vector2(Convert.ToSingle(pivotDesc["x"]), Convert.ToSingle(pivotDesc["y"]));
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
