
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.Physics.Hybrid.Authoring
{
    [AddComponentMenu("Physics/Collision Filter")]
    public class CollisionFilterAuthoring : MonoBehaviour
    {
        public CollisionLayer belongsTo = CollisionLayer.Environment;

        public CollisionLayer collidesWith = CollisionLayer.Everything;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CollisionFilterAuthoring))]
    public class CollisionLayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var layer = (CollisionFilterAuthoring)target;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical("Box");

            EditorGUI.indentLevel = 0;

            EditorGUILayout.LabelField("Filter");

            EditorGUI.indentLevel = 1;

            GUILayout.Space(5);

            layer.belongsTo = (CollisionLayer)EditorGUILayout.EnumFlagsField("Belongs To", layer.belongsTo);

            layer.collidesWith = (CollisionLayer)EditorGUILayout.EnumFlagsField("Collides With", layer.collidesWith);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(layer, "Changed Layers");

                EditorUtility.SetDirty(layer);

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
#endif
}
