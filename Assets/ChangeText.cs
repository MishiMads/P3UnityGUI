using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : UnitySocketClient
{
    //public TMP_Text canvasText;
    public TMP_Text repText;

    public TMP_Text assText;

    private int assessmentScoreInt;

    public int Reps;
    
    
    // private string textVariable = UnitySocketClient.currentReps;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            assText.text = "Assessment: Try again";
            Reps += 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            assText.text = "Assessment: Good";
            Reps += 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            assText.text = "Assessment: Very good";
            Reps += 1;
        }


        repText.text = "Reps: " + Reps;


        if (UnitySocketClient.currentReps != null)
        {
            repText.text = "Reps: " + currentReps;
        }


        if (UnitySocketClient.assessmentScore != null)
        {
            
            assessmentScoreInt = int.Parse(assessmentScore);
            
            if (assessmentScoreInt < 25)
            {
                assText.text = "Assessment: Try again";
            }
            
            if (assessmentScoreInt >= 25 && assessmentScoreInt < 75)
            {
                assText.text = "Assessment: Good";
            }
            
            if (assessmentScoreInt >= 75)
            {
                assText.text = "Assessment: Very good";
            }
            
            //If we need to display the exact score: assText.text = "Assessment Score: " + assessmentScore + "%";
                
        }
    }
}
