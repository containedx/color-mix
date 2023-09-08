using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image img;
    public Image background;

    private void Start()
    {
        RandomColorBackground();
    }

    public void RandomColorBackground()
    {
        var red = Random.value;
        var green = Random.value;
        var blue = Random.value;

        background.color = new Color(red, green, blue);
        Debug.Log(background.color);
    }

}
