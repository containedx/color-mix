using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public TMP_Text textThreshold;
    public Notification notification;
    public GameObject submitButton;

    public Image square;
    public Image background;

    public ColorSlider red;
    public ColorSlider green;
    public ColorSlider blue;

    private float winThreshold = 30;


    private void Start()
    {
        ShowMenu(true);
        notification.ShowNotification(false);
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
        ChangeColor();
    }

    public void ChangeColor()
    {
        notification.ShowNotification(false);
        ShowSubmit(false);

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

    public void Submit()
    {
        notification.ShowNotification(true);
        notification.SetBackgroundColor(square.color);
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
        notification.SetScore(100 - (int)difference);
        if( difference <= winThreshold )
        {
            // color matches (at least within given threshold)
            //ChangeColor();

            //ShowNotification(true);
            //notification.GetComponentInChildren<Image>().color = square.color;

            ShowSubmit(true);
        }
        else
        {
            ShowSubmit(false);
        }
    }

    public void ShowMenu(bool value)
    {
        menu.SetActive(value);
    }

    private void ShowSubmit(bool value)
    {
        submitButton.SetActive(value);
    }

}
