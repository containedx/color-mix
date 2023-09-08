using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixTest : MonoBehaviour
{
    
    public Image img;


    // Start is called before the first frame update
    void Start()
    {

	var red = new Color(255, 0, 0, 100);
	var blue = new Color(0, 0, 255, 100);
	var green = new Color(0, 255, 0, 100);


	img.color = green + red;
	Debug.Log(img.color); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
