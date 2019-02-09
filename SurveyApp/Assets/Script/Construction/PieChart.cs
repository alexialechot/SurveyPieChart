using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieChart : MonoBehaviour
{

    public Text totalText;
    public int total = 0;

    public Text textTotalOption0;
    public Text textTotalOption1;
    public Text textTotalOption2;

    public int totalOption0 = 0;
    public int totalOption1 = 0;
    public int totalOption2 = 0;

    public Text textPercentage0;
    public Text textPercentage1;
    public Text textPercentage2;

    public float Percentage0 = 0F;
    public float Percentage1 = 0F;
    public float Percentage2 = 0F;

    public float[] options;
    public Color[] PieColors;
    public Image PiePrefab;

    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------ START ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    void Start()
    {
        //-------------------------------------------- color ---------------------------------------------------
        textPercentage0.color = PieColors[0];
        textPercentage1.color = PieColors[1];
        textPercentage2.color = PieColors[2];
        //----------------------------------------- make the PIE -----------------------------------------------
        if (total != 0)
        {
            Pie();
        }
        //----------------------------------------- Set the TEXT -----------------------------------------------
        textTotalOption0.text = totalOption0.ToString();
        textTotalOption1.text = totalOption1.ToString();
        textTotalOption2.text = totalOption2.ToString();
        totalText.text = total.ToString();
    }
    //----------------------------------------------------------------------------------------------------------
    //----------------------------------------------- UPDATE ---------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (total != 0)
        {
            Percentage0 = 100 * totalOption0 / total;
            textPercentage0.text = Percentage0.ToString() + " %";

            Percentage1 = 100 * totalOption1 / total;
            textPercentage1.text = Percentage1.ToString() + " %";

            Percentage2 = 100 * totalOption2 / total;
            textPercentage2.text = Percentage2.ToString() + " %";
        }
    }
    //----------------------------------------------------------------------------------------------------------
    //-------------------------------------------- VisitorNumber -----------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    public void VisitorNumber()
    {
        total++;
        totalText.text = total.ToString();
    }
    //----------------------------------------------------------------------------------------------------------
    //----------------------------------------------- OPTIONS --------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
    // Call Option with Buttons
    public void Option0()
    {
        totalOption0++;
        textTotalOption0.text = totalOption0.ToString();
        options[0] = totalOption0;
        Pie();
    }
    public void Option1()
    {
        totalOption1++;
        textTotalOption1.text = totalOption1.ToString();
        options[1] = totalOption1;
        Pie();
    }
    public void Option2()
    {
        totalOption2++;
        textTotalOption2.text = totalOption2.ToString();
        options[2] = totalOption2;
        Pie();
    }

    //----------------------------------------------------------------------------------------------------------
    //------------------------------------------------- PIE ----------------------------------------------------
    //----------------------------------------------------------------------------------------------------------
	void Pie()
    {
        float zRotation = 0F;
        float totalPie = 0F;

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
