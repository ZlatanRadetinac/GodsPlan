using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class InsultProvider : MonoBehaviour
{
    private HashSet<Insult> Insults { get; }

    public InsultProvider() : this(new StreamReader("Assets/Resources/Text/insults.txt"))
    {
    }

    public InsultProvider(StreamReader reader)
    {
        Insults = new HashSet<Insult>();

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                var challenge = reader.ReadLine();
                var response = reader.ReadLine();
                Debug.Log(response);

                Insults.Add(new Insult(challenge, response));

                reader.ReadLine();
            }
        }
    }

    public InsultProvider(TextAsset textAsset)
    {

    }

    public void LoadInsults()
    {
        AssetDatabase.LoadAssetAtPath("../../Resources/Text/insults.txt", typeof(TextAsset));
    }

    public (Insult insult, List<string> wrongAnswers) GetRandomInsult()
    {
        Debug.Log("Insults: " + Insults.Count);

        var insult = Insults.ElementAt(Random.Range(0, Insults.Count));
        var wrongAnswers = Insults
            .Where(i => i.CorrectResponseLine != insult.CorrectResponseLine)
            .Select(x => x.CorrectResponseLine)
            .OrderBy(x => Random.Range(0f, 1f))
            .ToList();

        return (insult, wrongAnswers);
    }
}