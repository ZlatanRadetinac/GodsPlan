using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class InsultProvider : ScriptableObject
{
    private HashSet<Insult> Insults { get; }

    public InsultProvider(StreamReader reader)
    {
        Insults = new HashSet<Insult>();

        while (!reader.EndOfStream)
        {
            var challenge = reader.ReadLine();
            var response = reader.ReadLine();

            Insults.Add(new Insult(challenge, response));
        }
    }

    public Insult GetRandomInsult()
    {
        return Insults.ElementAt(Random.Range(0, Insults.Count));
    }

    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
}