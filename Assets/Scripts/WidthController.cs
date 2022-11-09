using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidthController : MonoBehaviour
{
    public float minValue = 0.1f, maxValue = 1.0f, value = 0.2f;
    public Slider widthSlider;
    public DrawableRawImage DRI;
    LineRenderer m_LineRenderer;

    void Start()
    {
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        m_LineRenderer.numCapVertices = 5;
        m_LineRenderer.positionCount  = 0;
        m_LineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        m_LineRenderer.startWidth = value;
        m_LineRenderer.endWidth   = value;
        m_LineRenderer.startColor = Color.black;
        m_LineRenderer.endColor   = Color.black;

        DRI.width = value;

        widthSlider.minValue = minValue;
        widthSlider.maxValue = maxValue;
        widthSlider.value    = value;
        widthSlider.onValueChanged.AddListener(OnWidthChanged);

        RectTransform rt = widthSlider.GetComponent<RectTransform>();
        Vector2 pos = new Vector2(rt.anchorMin.x * Screen.width, rt.anchorMin.y * Screen.height);
        pos   += rt.anchoredPosition;
        pos.x -= rt.rect.width / 2 + 40;
        pos = Camera.main.ScreenToWorldPoint(pos);

        m_LineRenderer.positionCount = 2;
        m_LineRenderer.SetPosition(0, pos);
        m_LineRenderer.SetPosition(1, pos);
    }

    public void OnWidthChanged(float w)
    {
        DRI.width = widthSlider.value;
        m_LineRenderer.startWidth = widthSlider.value;
        m_LineRenderer.endWidth   = widthSlider.value;
    }
}
