using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public TMP_Text textThreshold;
    public GameObject notification;

    public Image square;
    public Image background;

    public ColorSlider red;
    public ColorSlider green;
    public ColorSlider blue;

    private float winThreshold = 30;


    private void Start()
    {
        ChangeColor();
        ShowMenu(true);
        ShowNotification(false);
    }

    private void Update()
    {
        UpdateColor();
        CheckWin();
    }

    public void StartGame(float threshold)
    {
        winThreshold = threshold;
        ShowMenu(false);
    }

    public void ChangeColor()
    {
        ShowNotification(false);

        var r = Random.value;
        var g = Random.value;
        var b = Random.value;

        red.setTargetValue(r);
        green.setTargetValue(g);
        blue.setTargetValue(b);

        background.color = new Color(r, g, b);
        //Debug.Log(background.color);
    }

    public void Help()
    {
        red.ToggleHelp();
        green.ToggleHelp();
        blue.ToggleHelp();
    }

    private void UpdateColor()
    {
        var r = red.getValue();
        var g = green.getValue();
        var b = blue.getValue();

        square.color = new Color(r, g, b);
    }

    private void CheckWin()
    {
        var difference = red.getHowCloseTo100Percent() + blue.getHowCloseTo100Percent() + green.getHowCloseTo100Percent();
        textThreshold.text = difference + "%";
        if( difference <= winThreshold )
        {
            // color matches (at least within given threshold)
            //ChangeColor();

            ShowNotification(true);
            notification.GetComponentInChildren<Image>().color = square.color;
        }
    }

    private void ShowMenu(bool value)
    {
        menu.SetActive(value);
    }

    private void ShowNotification(bool value)
    {
        notification.SetActive(value);
    }

}
