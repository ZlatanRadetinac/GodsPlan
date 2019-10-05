using System;

public struct Insult
{
    public string ChallengeLine { get; }

    public string CorrectResponseLine { get; }

    public Insult(string challenge, string response)
    {
        ChallengeLine = challenge;
        CorrectResponseLine = response;
    }

    public bool ValidateResponse(string responseLine)
    {
        return (responseLine.Equals(CorrectResponseLine, StringComparison.InvariantCultureIgnoreCase));
    }
}
