using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PiChartToggleDefault : MonoBehaviour {


    public int OptionsTotal;

    public Text totalText;
    public int total = 0;
    public Text totalVisiteursText;
    public int totalVisiteurs = 0;

    public Toggle[] toggleOptions;

    public Text[] textTotalOptions;
    public int[] totalOptions;

    public Text[] textPercentages;
    public float[] Percentages;

    public Button buttonEnter;

    public float[] options; // Pie need a float ... but exactly the same as totalOptions
    public Color[] PieColors;
    public Image PiePrefab;

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
        //--------------------------------------------- COLOR ---------------------------------------------------
        // set the colors of the text
        for (int i = 0; i < textPercentages.Length; i++)
        {
            textPercentages[i].color = PieColors[i];
        }
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            textTotalOptions[i].text = totalOptions[i].ToString();

        }

        //------------------------------------------- Set the TEXT ---------------------------------------------
        totalVisiteursText.text = totalVisiteurs.ToString();
        totalText.text = total.ToString();
        //----------------------------------------- make the PIE -----------------------------------------------
        if (totalVisiteurs != 0)
        {
            Pie();
        }
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ UPDATE --------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    void Update()
    {
        //------------------------------------------ PERCENTAGES ----------------------------------------------
        // make the percentages
        if (total != 0)
        {
            for (int i = 0; i < totalOptions.Length; i++)
            {
                Percentages[i] = 100 * totalOptions[i] / total;
                textPercentages[i].text = Percentages[i].ToString() + " %";
            }
        }
        //------------------------------------------- TIMES -------------------------------------------------
        // Time before reset
        // Reset = Nothing selected
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
        // Stay time of thanks page
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
        //--------------------------------------- DECORATION ON CLICK ----------------------------------------
        // Interactable buttonEnter when a ToggleOption isOn
        // Change color of buttonEnter
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            if (toggleOptions[i].isOn)
            {
                buttonEnter.GetComponent<Button>().enabled = true;
                //ColorBlock colors = buttonEnter.colors;
                //colors.normalColor = new Color32(255, 0, 0, 255);
                //buttonEnter.colors = colors;
            }
        }


        //--------------------------------------- VALIDATION ENABLED ------------------------------------------
        //Check if one of the options is selected
        bool allTogglesOff = true;
        for (int i = 0; i < toggleOptions.Length; ++i)
        {
            if (toggleOptions[i].isOn)
            {
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
    // call with Enter Button
    public void Enter()
    {
        // Only if something is selected
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            if (toggleOptions[i].isOn)
            {
                totalOptions[i]++;
                textTotalOptions[i].text = totalOptions[i].ToString();
                options[i] = totalOptions[i];
                Total();
            }
        }
        Pie();
        Reset();
        timeOut = false;
        Thanks();
        TotalVisiteur();
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ TOTAL ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // Each time Enter is pressed x each option
    public void Total()
    {
        total++;
        totalText.text = total.ToString();
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ VISITORS ------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    //each time Enter is pressed
    private void TotalVisiteur()
    {
        totalVisiteurs++;
        totalVisiteursText.text = totalVisiteurs.ToString();
    }
    //--------------------------------------------------------------------------------------------------------
    //------------------------------------------------ PIE ---------------------------------------------------
    //--------------------------------------------------------------------------------------------------------
    // Make the pie
    void Pie()
    {
        float zRotation = 0F;
        float totalPie = 0F;
        if (total != 0)
        {
            for (int i = 0; i < options.Length; i++)
            {
                totalPie += options[i];
            }
            for (int i = 0; i < options.Length; i++)
            {
                Image newPie = Instantiate(PiePrefab) as Image;
                newPie.transform.SetParent(transform, false);
                newPie.color = PieColors[i];
                newPie.fillAmount = options[i] / totalPie;
                newPie.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
                zRotation -= newPie.fillAmount * 360f;
            }
        }
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
    // call thanks page. called in the Enter Button 
    public void Thanks()
    {
        thanks.GetComponent<Image>().enabled = true;
        thanksTimeLeft = theThanksTimeLeft;
        thanksTime = true;
    }
    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ RESET ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // Reset the options if no ones press enter. Called in Update
    private void Reset()
    {
        for (int i = 0; i < toggleOptions.Length; i++)
        {
            toggleOptions[i].isOn = false;
        }
    }
}
