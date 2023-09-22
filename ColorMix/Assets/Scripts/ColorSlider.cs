using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_Text textPercent;

    private float targetValue;
    private bool help = false;
    private float percentage;


    private void Start()
    {
        ResetPercentage();
    }

    private void Update()
    {
        CalculatePercentage();

    }

    public float getPercentage()
    {
        return percentage;
    }

    public float getHowCloseTo100Percent()
    {
        return 100 - percentage;
    }

    public float getValue()
    {
        return slider.value;
    }

    public void setTargetValue(float value)
    {
        targetValue = value;
    }

    
    public void ToggleHelp()
    {
        help = !help;
        ResetPercentage();
    }

    private void ResetPercentage()
    {
        textPercent.text = "";
    }

    private void CalculatePercentage()
    {
        var difference = Mathf.Abs(targetValue - slider.value) * 100;
        difference = Mathf.Round(difference);
        difference = 100 - difference;
        
        if (help)
        {
            textPercent.text = difference + "%";
        }

        percentage = difference;
    }

}
