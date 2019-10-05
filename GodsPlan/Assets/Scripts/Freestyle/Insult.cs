using System;
using UnityEngine;

public class Insult : MonoBehaviour
{
    public Insult(string challenge, string response)
    {
        ChallengeLine = challenge;
        CorrectResponseLine = response;
    }

    public string ChallengeLine { get; }

    public string CorrectResponseLine { get; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool ValidateResponse(string responseLine)
    {
        return (responseLine.Equals(CorrectResponseLine, StringComparison.InvariantCultureIgnoreCase));
    }
}
