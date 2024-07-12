using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

/// <summary> Sets a background color for game objects in the Hierarchy tab</summary>
[InitializeOnLoad]
#endif
public class HierarchyObjectColor
{
    private const float offsetLeft = -16f; // needs to have space to show the unity icons

    static HierarchyObjectColor()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var obj = EditorUtility.InstanceIDToObject(instanceID);
        if (obj != null)
        {
            float r;
            float g;
            float b;

            Color backgroundColor = Color.white;
            Color textColor = Color.white;
            Texture2D texture = null;

            // Write your object name in the hierarchy.
            switch (obj.name)
            {
                case "--- Managers ---":
                    // RGBA values
                    r = 146f / 255f;
                    g = 179f / 255f;
                    b = 244f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;

                case "--- Setup ---":
                    // RGBA values
                    r = 245f / 255f;
                    g = 227f / 255f;
                    b = 181f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;

                case "--- Environment ---":
                    // RGBA values
                    r = 179f / 255f;
                    g = 225f / 255f;
                    b = 167f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;

                case "--- Canvases ---":
                    // RGBA values
                    r = 229f / 255f;
                    g = 144f / 255f;
                    b = 168f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;

                case "--- Systems ---":
                    // RGBA values
                    r = 208f / 255f;
                    g = 142f / 255f;
                    b = 124f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;

                case "-------------------------":
                    // RGBA values
                    r = 221f / 255f;
                    g = 224f / 255f;
                    b = 231f / 255f;
                    backgroundColor = new Color(30f / 255f, 30f / 255f, 46f / 255f);
                    textColor = new Color(r, g, b);
                    break;
            }

            if (backgroundColor != Color.white)
            {
                Rect bgRect = new Rect(selectionRect.x - offsetLeft, selectionRect.y, selectionRect.width, selectionRect.height);

                EditorGUI.DrawRect(bgRect, backgroundColor);

                // Calculate centered text position
                GUIStyle style = new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = textColor },
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter
                };

                EditorGUI.LabelField(bgRect, obj.name, style);

                if (texture != null)
                    EditorGUI.DrawPreviewTexture(new Rect(selectionRect.position, new Vector2(selectionRect.height, selectionRect.height)), texture);
            }
        }
    }
}