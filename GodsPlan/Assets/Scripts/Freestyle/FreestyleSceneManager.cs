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

    private Insult CurrentInsult { get; set; }

    // Use this for initialization
    void Start()
    {
        if (this == Instance)
        {
            return;
        }

        Instance = this;
        UnityEngine.Random.InitState((int)DateTime.UtcNow.TimeOfDay.Ticks);

        var toggles = ResponsesGroup.GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnResponseSelected);
        }

        SetResponses();
    }

    void OnResponseSelected(bool toggleState)
    {
        if (toggleState)
        {
            var toggle = ResponsesGroup.ActiveToggles().Single();

            var isCorrect = CurrentInsult.ValidateResponse(toggle.GetComponentInChildren<Text>().text);

            if (isCorrect)
            {
                Debug.Log("You are amazing!!");
            }
            else
            {
                Debug.Log("You are bad");
            }

            SetResponses();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Insult NewRhyme()
    {
        return InsultProvider.GetRandomInsult().insult;
    }

    private void SetResponses()
    {
        ResponsesGroup.SetAllTogglesOff();

        (var insult, var wrongAnswers) = InsultProvider.GetRandomInsult();

        Debug.Log(wrongAnswers.Count);

        var toggles = ResponsesGroup.GetComponentsInChildren<Toggle>();
        var correct = UnityEngine.Random.Range(0, toggles.Count());

        ChallengeText.text = insult.ChallengeLine;

        for (int i = 0; i < toggles.Count(); i++)
        {
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

        CurrentInsult = insult;
    }
}
