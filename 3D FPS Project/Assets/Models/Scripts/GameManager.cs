using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    private int _targetamount;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        int floatingTarget = GameObject.FindGameObjectsWithTag("TargetFloating").Length;
        int standingTarget = GameObject.FindGameObjectsWithTag("TargetStanding").Length;
        _targetamount = floatingTarget + standingTarget;
        targetText.text = "Targets:" + _targetamount.ToString();
    }

    public void UpdateTargeetAmount()
    {
        _targetamount -= 1;
        targetText.text = "Targets:" + _targetamount.ToString();

        if(_targetamount <= 0)
        {
            //stop the timer
            GameObject.Find("Game Manager").GetComponent<Timer>().EndGameTimer();
        }
    }
}
