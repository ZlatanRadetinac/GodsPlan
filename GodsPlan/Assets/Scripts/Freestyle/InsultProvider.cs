using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

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

    public InsultProvider(TextAsset textAsset)
    {

    }

    public void LoadInsults()
    {
        AssetDatabase.LoadAssetAtPath("../../Resources/Text/insults.txt", typeof(TextAsset));
    }

    public Insult GetRandomInsult()
    {
        return Insults.ElementAt(Random.Range(0, Insults.Count));
    }
}