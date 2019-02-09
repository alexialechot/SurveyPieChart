using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PercentageToggle : MonoBehaviour
{
    public Text totalVisiteursText;
    public int totalVisiteurs = 0;

    public Toggle[] toggleOptions;
    public Image[] toggleBackgrounds;
    public Image[] toggleCheckmarks;

    public Text[] textTotalOptions;
    public int[] totalOptions;

    public Text[] textPercentages;
    public float[] Percentages;

    public Button buttonEnter;


    float timeLeft;
    public float TheTimeLeft = 60.0f;
    bool timeOut = false;
    float thanksTimeLeft;
    public float theThanksTimeLeft = 3.0f;
    bool thanksTime = false;
    public Image thanks;
    

    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ START ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    void Start()
    {
        //------------------------------------------ Set the TEXT -----------------------------------------------
        totalVisiteursText.text = totalVisiteurs.ToString();
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ UPDATE --------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    void Update()
    {
        //------------------------------------------ PERCENTAGES ------------------------------------------------
        // make the percentages
        if (totalVisiteurs != 0)
        {
            for (int i = 0; i < totalOptions.Length; i++)
            {
                Percentages[i] = 100 * totalOptions[i] / totalVisiteurs;
                textPercentages[i].text = Percentages[i].ToString() + " %";
            }
        }
        //-------------------------------------------- TIMES ---------------------------------------------------
        // Time before reset
        if (timeOut == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                Debug.Log("time is left");
                Reset();
                timeOut = false;
            }
        }
        // Time of thanks page stay
        if (thanksTime == true)
        {
            thanksTimeLeft -= Time.deltaTime;
            if (thanksTimeLeft <= 0.0f)
            {
                //Debug.Log("thanksTime is left");
                thanks.GetComponent<Image>().enabled = false;
                thanksTime = false;
            }
        }
        //------------------------------------------------ DECORATION ON CLICK ---------------------------------------------------
        // call checkmarks deco when a ToggleOption isOn
        // Interactable buttonEnter when a ToggleOption isOn
        // Change color of buttonEnter

        for (int i = 0; i < toggleOptions.Length; i++)
            {
                if (toggleOptions[i].isOn)
                {
                    toggleCheckmarks[i].GetComponent<Image>().enabled = true;
                    buttonEnter.GetComponent<Button>().enabled = true;
                    //ColorBlock colors = buttonEnter.colors;
                    //colors.normalColor = new Color32(255, 0, 0, 255);
                    //buttonEnter.colors = colors;
                }
               else
               {
                   toggleCheckmarks[i].GetComponent<Image>().enabled = false;
                }
           }
        //------------------------------------------------ VALIDATION ENABLED ---------------------------------------------------
        //Check if one of the options is selected
        bool allTogglesOff = true;
        for (int i = 0; i < toggleOptions.Length; ++i)
        {
            if (toggleOptions[i].isOn){
                allTogglesOff = false;
                break;
            }
        }
        // if it's not the case (no ones is selected)
        if (allTogglesOff)
        {
            //Debug.Log("All the Toggle are false");
            // the validation button is not enabled
            buttonEnter.GetComponent<Button>().enabled = false;
        }
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ ENTER ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // called with Enter Button
    public void Enter()
    {
        // Only if something is selected
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            if (toggleOptions[i].isOn)
            {
                totalOptions[i]++;
                textTotalOptions[i].text = totalOptions[i].ToString();
            }
        }
        Reset();
        timeOut = false;
        Thanks();
        TotalVisiteur();
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ VISITORS ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    //each time Enter is pressed
    private void TotalVisiteur()
    {
        totalVisiteurs++;
        totalVisiteursText.text = totalVisiteurs.ToString();
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ TIME ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // called with the Options buttons (toggleOptions 0 1 2)
    public void TimeOut()
    {
        timeLeft = TheTimeLeft;
        timeOut = true;
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ THANKS ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // call thanks page. Called with the Enter Button 
    public void Thanks()
    {
        thanks.GetComponent<Image>().enabled = true;
        thanksTimeLeft = theThanksTimeLeft;
        thanksTime = true;
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ RESET ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // Reset the options if no ones press enter Called in Update
    private void Reset()
    {
        //Debug.Log("Reset time !");
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            toggleOptions[i].isOn = false;
            //Debug.Log((toggleOptions[i]) + " = false");
        }
	}
 }
