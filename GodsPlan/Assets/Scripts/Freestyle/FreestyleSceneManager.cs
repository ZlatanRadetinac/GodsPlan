using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FreestyleSceneManager : MonoBehaviour
{
    public static FreestyleSceneManager Instance { get; private set; }

    public InsultProvider InsultProvider;
    public Text ChallengeText;
    public ToggleGroup ResponsesGroup;

    // Use this for initialization
    void Start()
    {
        if (this == Instance)
        {
            return;
        }

        Instance = this;
        UnityEngine.Random.InitState((int)DateTime.UtcNow.TimeOfDay.Ticks);

        ResponsesGroup.SetAllTogglesOff();

        SetResponses();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hewwo!");

        var toggles = ResponsesGroup.GetComponentsInChildren<Toggle>();

        Debug.Log(toggles.Count());

        Debug.Log(Path.GetFullPath("."));
    }

    private Insult NewRhyme()
    {
        return InsultProvider.GetRandomInsult().insult;
    }

    private void SetResponses()
    {
        (var insult, var wrongAnswers) = InsultProvider.GetRandomInsult();

        Debug.Log(wrongAnswers.Count);

        var toggles = ResponsesGroup.GetComponentsInChildren<Toggle>();
        var correct = UnityEngine.Random.Range(0, toggles.Count());

        ChallengeText.text = insult.ChallengeLine;

        for (int i = 0; i < toggles.Count(); i++)
        {
            //toggles[i].isOn = false;
            var label = toggles[i].GetComponentInChildren<Text>();
            if (i == correct)
            {
                label.text = insult.CorrectResponseLine;
            }
            else
            {
                label.text = wrongAnswers[i];
            }
        }
    }
}
