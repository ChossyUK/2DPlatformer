using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEX : Editor
{
    PlayerController playerController;

    private void OnEnable()
    {
        playerController = (PlayerController)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("2D Platform Controller", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 16 });
        GUILayout.Label("Cedarwood Software Version: 1.0", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter });
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        base.DrawDefaultInspector();
    }
}
#endif