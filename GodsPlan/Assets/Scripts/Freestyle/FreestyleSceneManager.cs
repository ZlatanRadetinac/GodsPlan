using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FreestyleSceneManager : MonoBehaviour
{
    public static FreestyleSceneManager Instance { get; private set; }

    public InsultProvider InsultProvider;
    public Text ChallengeText;
    public Text HypeText;
    public ToggleGroup ResponsesGroup;
    public RawImage Score;
    public Image Rihanna;

    private Insult CurrentInsult { get; set; }

    private int CurrentScore { get; set; }

    // Use this for initialization
    void Start()
    {
        if (this == Instance)
        {
            return;
        }

        Instance = this;

        Score.color = new Color(1.0f, 0.5f, 0.5f);
        CurrentScore = 50;
        UnityEngine.Random.InitState((int)DateTime.UtcNow.TimeOfDay.Ticks);
        HypeText.text = "CRUSH YOUR OPPONENT";
        Rihanna.enabled = false;

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
                CurrentScore += 10;
                HypeText.text = "AMAZING";
                Score.color = new Color(Score.color.r, Score.color.b - 0.125f, Score.color.g - 0.125f);
                Score.rectTransform.sizeDelta = new Vector2(Score.rectTransform.rect.width + 20, Score.rectTransform.rect.height);

                if (CurrentScore >= 100)
                {
                    Rihanna.enabled = true;
                    // TODO: next level
                }
            }
            else
            {
                HypeText.text = "YOUR MOVES ARE WEAK";
                Score.color = new Color(Score.color.r, Score.color.b + 0.125f, Score.color.g + 0.125f);
                Score.rectTransform.sizeDelta = new Vector2(Score.rectTransform.rect.width - 20, Score.rectTransform.rect.height);
                CurrentScore -= 10;
                if (CurrentScore <= 0)
                {
                    // TODO: game over
                }
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
