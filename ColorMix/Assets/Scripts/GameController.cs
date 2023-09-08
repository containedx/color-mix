using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image square;
    public Image background;

    public ColorSlider red;
    public ColorSlider green;
    public ColorSlider blue;


    private void Start()
    {
        RandomColorBackground();
    }

    private void Update()
    {
        UpdateColor();
    }

    public void RandomColorBackground()
    {
        var r = Random.value;
        var g = Random.value;
        var b = Random.value;

        background.color = new Color(r, g, b);
        Debug.Log(background.color);
    }

    private void UpdateColor()
    {
        var r = red.getValue();
        var g = green.getValue();
        var b = blue.getValue();

        square.color = new Color(r, g, b);
    }

}
