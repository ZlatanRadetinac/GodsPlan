using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InsultProvider : MonoBehaviour
{
    private HashSet<Insult> Insults { get; } = new HashSet<Insult>();

    private HashSet<Insult> UsedInsults { get; } = new HashSet<Insult>();

    private IEnumerable<Insult> UnusedInsults => Insults.Except(UsedInsults);    

    public void Awake()
    {
        var insults = Resources.Load<TextAsset>("Text/insults");
        var lines = insults.text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        Debug.Log("Total insult lines: " + lines.Length);

        for (int i = 0; i < lines.Length; i += 2)
        {
            Insults.Add(new Insult(lines[i], lines[i + 1]));
        }
    }

    public (Insult insult, List<string> wrongAnswers) GetRandomInsult(bool onlyUnused = true)
    {
        Debug.Log("Insults: " + Insults.Count);

        var insultSet = onlyUnused ? UnusedInsults : Insults;
        var insult = insultSet.ElementAt(UnityEngine.Random.Range(0, insultSet.Count()));

        var wrongAnswers = Insults
            .Where(i => i.CorrectResponseLine != insult.CorrectResponseLine)
            .Select(x => x.CorrectResponseLine)
            .OrderBy(x => UnityEngine.Random.Range(0f, 1f))
            .ToList();

        UsedInsults.Add(insult);

        return (insult, wrongAnswers);
    }
}