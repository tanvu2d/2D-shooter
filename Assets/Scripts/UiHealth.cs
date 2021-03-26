using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UiHealth : MonoBehaviour
{
    public static UiHealth instance { get; private set;  }
    public Image mark;
    float originalSize;

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        originalSize = mark.rectTransform.rect.width;
    }

    public  void Setvalue (float value)
    {
        mark.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);

    }

}
