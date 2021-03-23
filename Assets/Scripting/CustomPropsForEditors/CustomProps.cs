using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class CustomProps : ScriptableObject
{
    [SerializeField]
    public Color ErrorColor;
    [SerializeField]
    public Color MainTitleColor;
    [SerializeField]
    public int MainTitleFontSize = 24;
    [SerializeField]
    public int SubTitleFontSize = 18;
    [FormerlySerializedAs("customColors")]
    [SerializeField]
    public List<CustomProperties> customColors;
    [SerializeField]
    public List<GUIStyle> GUIStyles;

    public GUIStyle GetByName(string guiStyleName)
    {
        return GUIStyles.Find(x => x.name.Equals(guiStyleName));
    }

    public static GUIStyle GetProp(string guiStyleName)
    {
        CustomProps customProps = new CustomProps();


        if (EditorPrefs.HasKey("customPropsPath"))
        {
            string objectPath = EditorPrefs.GetString("customPropsPath");
            customProps = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CustomProps)) as CustomProps;
            Debug.Log($"Loaded at {objectPath}");
            return customProps.GUIStyles.Find(x => x.name.Equals(guiStyleName));

        }
        else
        {
            Debug.LogWarning("No EditoPrefs Defined");
            return new GUIStyle();
        }
    }

}
