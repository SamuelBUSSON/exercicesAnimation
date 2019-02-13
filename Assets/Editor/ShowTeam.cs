using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class ShowTeam
{
    static ShowTeam()
    {
        var team = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Equipe.txt");
        if (team.text == "Membres de l'équipe")
        {
            EditorUtility.DisplayDialog("Identification", "N'oubliez pas d'indiquer le nom de vos coéquipiers dans le fichier \"Assets/Equipe.txt\"!!", "Compris!");
        }

        Debug.Log(team.text);
    }
}
