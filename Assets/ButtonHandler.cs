using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Button Øvelse1;
    [SerializeField] private Button Øvelse2;
    [SerializeField] private Button Øvelse3;
    
    private void goToØvelse1()
    {
        Debug.Log("Øvelse 1");
    }

}
