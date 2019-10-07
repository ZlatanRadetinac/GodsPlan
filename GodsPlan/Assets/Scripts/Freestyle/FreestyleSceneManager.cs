using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FreestyleSceneManager : MonoBehaviour
{
    public static FreestyleSceneManager Instance { get; private set; }

    public InsultProvider InsultProvider;
    public Text ChallengeText;
    public Text HypeText;
    public Countdown AnswerCountdown;
    public ToggleGroup ResponsesGroup;
    public RawImage Score;
    public Image Rihanna;
    public Canvas LevelCompletedCanvas;
    public GameObject ResponsePanel;

    private Insult CurrentInsult { get; set; }

    private int CurrentScore { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        LevelCompletedCanvas.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        if (this == Instance)
        {
            return;
        }

        Instance = this;

        Score.color = new Color(1.0f, 0.5f, 0.5f);
        CurrentScore = 100;
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

            ProcessResponse(isCorrect);
        }
    }

    public void ProcessResponse(bool isResponseCorrect)
    {
        if (isResponseCorrect)
        {
            CurrentScore += 25;
            HypeText.text = "AMAZING";
            Score.color = new Color(Score.color.r, Score.color.b - 0.125f, Score.color.g - 0.125f);
            Score.rectTransform.sizeDelta = new Vector2(Score.rectTransform.rect.width + 20, Score.rectTransform.rect.height);

            if (CurrentScore >= 200)
            {
                Rihanna.enabled = true;
                HypeText.enabled = false;
                Score.enabled = false;
                ResponsesGroup.enabled = false;
                // TODO: next level
                ResponsePanel.SetActive(false);
                Invoke("LevelCompleted", 3);
            }
        }
        else
        {
            HypeText.text = "YOUR MOVES ARE WEAK";
            Score.color = new Color(Score.color.r, Score.color.b + 0.125f, Score.color.g + 0.125f);
            Score.rectTransform.sizeDelta = new Vector2(Score.rectTransform.rect.width - 20, Score.rectTransform.rect.height);
            CurrentScore -= 25;
            
            if (CurrentScore <= 0)
            {
                ResponsePanel.SetActive(false);
                Invoke("LevelCompleted", 3);
            }
        }

        SetResponses();
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

        AnswerCountdown.ResetCountdown();
    }

    public void LevelCompleted()
    {
        LevelCompletedCanvas.gameObject.SetActive(true);
    }

    public void ProceedToFtBrihanna()
    {
        SceneManager.LoadScene("MoneyRainTmp", LoadSceneMode.Single);
    }
}
