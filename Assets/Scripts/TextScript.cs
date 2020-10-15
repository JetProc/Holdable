using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text[] numberText = new Text[4];
    public Text Score;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            numberText[i] = numberText[i].GetComponent<Text>();
        }
    }

}
