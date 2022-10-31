using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DrawableRawImage : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Camera drawCamera;
    public float width;
    public Color color;
    LineRenderer m_LineRenderer;

    void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        drawCamera.targetTexture = rt;
        GetComponent<RawImage>().texture = rt;

        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        m_LineRenderer.numCapVertices = 5;
        m_LineRenderer.positionCount  = 0;
        m_LineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        RenderTexture.active = rt;
        GL.Clear(true, true, Color.white);
        RenderTexture.active = null;
    }

    public void OnPointerDown(PointerEventData pd)
    {
        m_LineRenderer.startWidth = width;
        m_LineRenderer.endWidth   = width;
        m_LineRenderer.startColor = color;
        m_LineRenderer.endColor   = color;
        m_LineRenderer.positionCount = 2;
        Vector2 tempPos = Camera.main.ScreenToWorldPoint(pd.position);
        m_LineRenderer.SetPosition(0, tempPos);
        m_LineRenderer.SetPosition(1, tempPos);
    }

    public void OnPointerUp(PointerEventData pd)
    {
        m_LineRenderer.positionCount = 0;
    }

    public void OnDrag(PointerEventData pd)
    {
        Vector2 tempPos = Camera.main.ScreenToWorldPoint(pd.position);
        m_LineRenderer.positionCount++;
        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, tempPos);
    }

    public void SaveAsPNG()
    {
        RenderTexture rt = drawCamera.targetTexture;
        Texture2D t2D = new Texture2D(rt.width, rt.height);
        RenderTexture.active = rt;
        t2D.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        t2D.Apply();
        RenderTexture.active = null;
        byte[] bytes = t2D.EncodeToPNG();
        string fpath = Application.persistentDataPath + "/SavedImage-" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        System.IO.File.WriteAllBytes(fpath, bytes);
    }
}
