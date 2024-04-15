using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public int winScene;
    public int loseScene;
    private int _targetamount;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Game Manager").GetComponent<Timer>();
        Cursor.lockState = CursorLockMode.Locked;
        int floatingTarget = GameObject.FindGameObjectsWithTag("TargetFloating").Length;
        int standingTarget = GameObject.FindGameObjectsWithTag("TargetStanding").Length;
        _targetamount = floatingTarget + standingTarget;
        targetText.text = "Targets:" + _targetamount.ToString();
    }

    void Update()
    {
        if(_timer.GetTimeRemaining() <= 0)
        {
            SceneManager.LoadScene(loseScene);
        }
    }

    public void UpdateTargeetAmount()
    {
        _targetamount -= 1;
        targetText.text = "Targets:" + _targetamount.ToString();

        if(_targetamount <= 0)
        {
            //stop the timer
            GameObject.Find("Game Manager").GetComponent<Timer>().EndGameTimer();

            //Send player to the win scene
            SceneManager.LoadScene(winScene);
        }
    }
}
