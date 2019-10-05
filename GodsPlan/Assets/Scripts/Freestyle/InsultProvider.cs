using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class InsultProvider : MonoBehaviour
{
    private HashSet<Insult> Insults { get; }

    private HashSet<Insult> UsedInsults { get; }

    private IEnumerable<Insult> UnusedInsults => Insults.Except(UsedInsults);

    public InsultProvider() : this(new StreamReader("Assets/Resources/Text/insults.txt"))
    {
    }

    public InsultProvider(StreamReader reader)
    {
        Insults = new HashSet<Insult>();
        UsedInsults = new HashSet<Insult>();

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

    public (Insult insult, List<string> wrongAnswers) GetRandomInsult(bool onlyUnused = true)
    {
        Debug.Log("Insults: " + Insults.Count);

        var insultSet = onlyUnused ? UnusedInsults : Insults;
        var insult = insultSet.ElementAt(Random.Range(0, insultSet.Count()));

        var wrongAnswers = Insults
            .Where(i => i.CorrectResponseLine != insult.CorrectResponseLine)
            .Select(x => x.CorrectResponseLine)
            .OrderBy(x => Random.Range(0f, 1f))
            .ToList();

        UsedInsults.Add(insult);

        return (insult, wrongAnswers);
    }
}