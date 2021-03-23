using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomProperties
{
    [SerializeField]
    public string PropertyName = string.Empty;
    [SerializeField]
    public Color PropertyColor;

    public static CustomProperties CreateProperty(string PropertyName, Color PropertyColor)
    {
        CustomProperties customProperties = new CustomProperties();
        customProperties.PropertyColor = PropertyColor;
        customProperties.PropertyName = PropertyName;
        return customProperties;
    }

    public Color GetColor()
    {
        if (PropertyColor == null)
            PropertyColor = Color.white;

        return PropertyColor;
    }
}
