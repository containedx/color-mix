using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuVisuals : MonoBehaviour
{
    public Image background;
    public TMP_Text text;

    private float time = 0.0f;
    private float interpolationPeriod = 0.5f;

    private Color colorB = Color.white;
    private Color invertedColor = Color.black;

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod) 
        {
            time = time - interpolationPeriod;
            var r = Random.value;
            var g = Random.value;
            var b = Random.value;

            colorB = new Color(r, g, b);
            invertedColor = new Color(1-r, 1-g, 1-b);
        }
        
    
        background.color = Color.Lerp(background.color, colorB, Time.deltaTime);
        text.color = Color.Lerp(text.color, invertedColor, Time.deltaTime);
    }


}
