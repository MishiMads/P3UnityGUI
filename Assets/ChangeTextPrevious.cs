using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextPrevious : UnitySocketClient
{
    //public TMP_Text canvasText;
    public TMP_Text repTextBicep;
    public TMP_Text repTextRejse;
    public TMP_Text repTextReach;

    public TMP_Text assTextBicep;
    public TMP_Text assTextRejse;
    public TMP_Text assTextReach;
    
    // private string textVariable = UnitySocketClient.currentReps;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitySocketClient.currentReps != null)
        {
            repTextBicep.text = "Reps: " + currentReps;
            repTextRejse.text = "Reps: " + currentReps;
            repTextReach.text = "Reps: " + currentReps;
        }
        if (UnitySocketClient.assessmentScore != null)
        {
            assTextBicep.text = "Assessment Score: " + assessmentScore + "%";
            assTextRejse.text = "Assessment Score: " + assessmentScore + "%";
            assTextReach.text = "Assessment Score: " + assessmentScore + "%";
        }
    }
}
