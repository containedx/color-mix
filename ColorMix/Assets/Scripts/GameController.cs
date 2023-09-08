using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image square;
    public Image background;

    public Slider red;
    public Slider green;
    public Slider blue;


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
        var r = red.value;
        var g = green.value;
        var b = blue.value;

        square.color = new Color(r, g, b);
    }

}
