using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    // Here put only the Toggle you whant to switch off when the special toggle is selected 
    public Toggle[] toggleOptions;
    public Toggle MySecialToggle; 

    // Call by my special toggle
    public void MyToggleGroup()
    {
        //All the other toggle will be false when the ( Toggle 1 - where this function is called ) is selected
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            // all the other Toggle is false
            toggleOptions[i].isOn = false;
            //Debug.Log((toggleOptions[i]) + " = false")
        }
    }

    // Call by all the other Toggle
    public void TheOthersToggle()
    {
        // My special Toggle is false
        MySecialToggle.isOn = false;
    }
}
