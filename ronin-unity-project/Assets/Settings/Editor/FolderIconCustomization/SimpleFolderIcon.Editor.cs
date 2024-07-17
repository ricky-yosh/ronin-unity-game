using System.IO;
using UnityEditor;
using UnityEngine;

namespace SimpleFolderIcon.Editor
{
    [InitializeOnLoad]
    public class CustomFolder
    {
        static CustomFolder()
        {
            EditorApplication.projectWindowItemOnGUI += DrawFolderIcon;
        }

        static void DrawFolderIcon(string guid, Rect rect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);

            if (path == "" ||
                Event.current.type != EventType.Repaint ||
                !File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                return;
            }

            string folderName = Path.GetFileName(path);

            // Skip the Assets folder
            if (folderName == "Assets")
            {
                return;
            }

            Texture2D texture = GetIconForFolder(folderName);

            if (texture == null)
            {
                return;
            }

            Rect imageRect;

            if (rect.height > 20)
            {
                imageRect = new Rect(rect.x - 1, rect.y - 1, rect.width + 2, rect.width + 2);
            }
            else if (rect.x > 20)
            {
                imageRect = new Rect(rect.x - 1, rect.y - 1, rect.height + 2, rect.height + 2);
            }
            else
            {
                imageRect = new Rect(rect.x + 2, rect.y - 1, rect.height + 2, rect.height + 2);
            }

            GUI.DrawTexture(imageRect, texture);
        }

        static Texture2D GetIconForFolder(string folderName)
        {
            string basePath = "Assets/Settings/Editor/FolderIconCustomization/Icons/";
            switch (folderName)
            {
                case "Animations":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Animations.png");
                case "Audio":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Audio.png");
                case "Editor":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Editor.png");
                case "Fonts":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Fonts.png");
                case "Materials":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Materials.png");
                case "Models":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Models.png");
                case "Plugins":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Plugins.png");
                case "Prefabs":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Prefabs.png");
                case "Presets":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Presets.png");
                case "Resources":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Resources.png");
                case "_Scenes":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Scenes.png");
                case "_Scripts":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Scripts.png");
                case "Scripts":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Scripts.png");
                case "Settings":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Settings.png");
                case "Shaders":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Shaders.png");
                case "_UI":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Sprites.png");
                case "Textures":
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Textures.png");
                default:
                    return AssetDatabase.LoadAssetAtPath<Texture2D>($"{basePath}Default.png");
            }
        }
    }
}
