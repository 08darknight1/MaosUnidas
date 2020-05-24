using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    public float timeGoal;

    private bool hitGoal;

    private float timeGoalInitialValue;

    private bool StartTimer = false;
    void Start()
    {
        timeGoalInitialValue = timeGoal;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitGoal == false)
        {
            if (StartTimer)
            {
                timeGoal -= Time.deltaTime;

                if (timeGoal <= 0)
                {
                    hitGoal = true;
                }
            }
        }
    }

    public void activateTimer()
    {
        StartTimer = true;
    }

    public bool returnGoalValue()
    {
        return hitGoal;
    }

    public void resetTimer()
    {
        timeGoal = timeGoalInitialValue;
        StartTimer = false;
        hitGoal = false;
    }

    public bool returnTimerState()
    {
        var needsReset = false;

        if (timeGoal != timeGoalInitialValue && hitGoal == false)
        {
            needsReset = true;
        }

        return needsReset;
    }
    
}
