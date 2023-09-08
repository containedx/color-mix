using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixTest : MonoBehaviour
{
    public Image img;
    public Image background;

    private void Start()
    {
        RandomColorBackground();
    }

    private void RandomColorBackground()
    {
        var red = Random.Range(0, 255);
        var green = Random.Range(0, 255);
        var blue = Random.Range(0, 255);

        background.color = new Color(red, green, blue);
        Debug.Log(background.color);
    }

}
