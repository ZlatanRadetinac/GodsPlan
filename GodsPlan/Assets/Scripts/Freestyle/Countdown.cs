using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    const int TimeToAnswer = 10;

    public Text CountdownDisplay;

    private Timer Timer { get; }

    private int CurrentValue { get; set; } = TimeToAnswer;

    public Countdown()
    {
        Timer = new Timer(1000);
        Timer.Elapsed += OnTimerTick;
        Timer.AutoReset = false;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTimerTick(object _, ElapsedEventArgs eea)
    {
        --CurrentValue;
        CountdownDisplay.text = CurrentValue.ToString("d2");

        if (CurrentValue <= 0)
        {
            var sceneManager = GetComponentInParent<FreestyleSceneManager>();
            sceneManager.ProcessResponse(false);
        }
    }

    public void ResetCountdown()
    {
        CurrentValue = TimeToAnswer;
        CountdownDisplay.text = CurrentValue.ToString("d2");
        Timer.Enabled = true;
    }
}
