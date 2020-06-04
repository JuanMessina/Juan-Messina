using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FloatToTextUI : MonoBehaviour
{
    public Text text;

    public void UpdateText(float newValue)
    {
        if (newValue < 10)
        {
            if (newValue == 0)
                text.text = "Time's up!";
            else
                text.text = newValue.ToString("0.0");
        }
    }
}
