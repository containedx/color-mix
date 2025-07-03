using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    public Image background;
    public TMP_Text textScore;
    
    public void SetScore(int value)
    {
        textScore.text = value + "%";
    }

    public void SetBackgroundColor(Color color)
    {
        background.color = color;
    }

    public void ShowNotification(bool value)
    {
        gameObject.SetActive(value);
    }
}
