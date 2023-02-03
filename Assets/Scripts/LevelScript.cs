using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public TMPro.TMP_Text highScoreTitleText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreTitleText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
