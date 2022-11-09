using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    public Button dropdownActivator;
    public GameObject dropdown;
    public DrawableRawImage DRI;

    bool m_Active;
    RectTransform m_DDRectTransform;
    Texture2D m_DropDownTexture;
    float m_WRatio, m_HRatio;

    void Start()
    {
        RawImage ri = dropdown.GetComponent<RawImage>();
        m_DropDownTexture = ri.texture as Texture2D;
        m_DDRectTransform = ri.GetComponent<RectTransform>();
        m_WRatio = m_DropDownTexture.width  / m_DDRectTransform.rect.width ;
        m_HRatio = m_DropDownTexture.height / m_DDRectTransform.rect.height;
        m_Active = false;

        dropdown.SetActive(false);
        DRI.color = Color.black;
        dropdownActivator.GetComponent<Image>().color = Color.black;
        dropdownActivator.onClick.AddListener(delegate {dropdown.SetActive(m_Active = !m_Active);});

        Button bt = dropdown.GetComponent<Button>();
        bt.onClick.AddListener(OnColorClicked);
    }

    public void OnColorClicked()
    {
        Vector2 colorPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_DDRectTransform, Input.mousePosition, Camera.main, out colorPos);
        colorPos.x = m_DDRectTransform.rect.width  / 2 + colorPos.x;
        colorPos.y = m_DDRectTransform.rect.height / 2 + colorPos.y;

        Color c = m_DropDownTexture.GetPixel((int)(colorPos.x * m_WRatio), (int)(colorPos.y * m_HRatio));
        dropdownActivator.GetComponent<Image>().color = c;
        DRI.color = c;

        m_Active = false;
        dropdown.SetActive(false);
    }
}
