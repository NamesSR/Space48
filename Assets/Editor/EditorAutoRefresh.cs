using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class EditorAutoRefresh
{
    static EditorAutoRefresh()
    {
        // Triggers a check every time the Unity editor updates its frame loop
        EditorApplication.update += OnEditorUpdate;
    }

    private static void OnEditorUpdate()
    {
        // If Unity has focus, force it to poll the filesystem for code changes
        if (UnityEditorInternal.InternalEditorUtility.isApplicationActive)
        {
            // Uses the standard 'Default' enum option
            AssetDatabase.Refresh(ImportAssetOptions.Default);
        }
    }
}
