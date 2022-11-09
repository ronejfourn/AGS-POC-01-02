using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    public Button dropdownActivator;
    public Slider rSlider, gSlider, bSlider;
    public GameObject dropdown;
    public DrawableRawImage DRI;

    bool m_Active;
    Image m_DDAImage;

    void Start()
    {
        m_Active   = false;
        m_DDAImage = dropdownActivator.GetComponent<Image>();

        dropdown.SetActive(false);
        DRI.color = Color.black;
        dropdownActivator.GetComponent<Image>().color = Color.black;
        dropdownActivator.onClick.AddListener(delegate {
                dropdown.SetActive(m_Active = !m_Active);
        });
        rSlider.onValueChanged.AddListener(delegate {
                DRI.color.r = rSlider.value;
                m_DDAImage.color = DRI.color;
        });
        gSlider.onValueChanged.AddListener(delegate {
                DRI.color.g = gSlider.value;
                m_DDAImage.color = DRI.color;
        });
        bSlider.onValueChanged.AddListener(delegate {
                DRI.color.b = bSlider.value;
                m_DDAImage.color = DRI.color;
        });
    }
}
