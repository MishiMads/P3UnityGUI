using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : UnitySocketClient
{
    //public TMP_Text canvasText;
    public TMP_Text repText;

    public TMP_Text assText;
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
            repText.text = "Reps: " + currentReps;
        }
        if (UnitySocketClient.assessmentScore != null)
        {
            assText.text = "Assessment Score: " + assessmentScore + "%";
        }
    }
}
