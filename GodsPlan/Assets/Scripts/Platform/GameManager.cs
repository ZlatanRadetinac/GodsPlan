using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool CanUserPlay;
    public Canvas LevelCompletedCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        LevelCompletedCanvas.gameObject.SetActive(false);
    }

    public void LevelCompleted()
    {
        CanUserPlay = false;
        LevelCompletedCanvas.gameObject.SetActive(true);
    }

    public void ProceedToRapBattleLevel()
    {
        SceneManager.LoadScene("InsultFight", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
