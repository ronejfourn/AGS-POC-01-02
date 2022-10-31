using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidthController : MonoBehaviour
{
    public float minValue, maxValue, value;
    public Slider widthSlider;
    public DrawableRawImage DRI;
    LineRenderer m_LineRenderer;

    void Start()
    {
        widthSlider.minValue = minValue;
        widthSlider.maxValue = maxValue;
        widthSlider.value    = value;

        DRI.width = value;

        widthSlider.onValueChanged.AddListener(delegate {DRI.width = widthSlider.value;});
    }
}
