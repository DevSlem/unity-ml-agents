using System.Reflection;
using UnityEditor;
using UnityEngine;
using DevSlem.Unity;

namespace DevSlem.UnityEditor
{
    [CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
    public sealed class OnValueChangedPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using var check = new EditorGUI.ChangeCheckScope();
            EditorGUI.PropertyField(position, property, label, true);
            if (EditorGUI.EndChangeCheck())
            {
                var attr = attribute as OnValueChangedAttribute;
                var flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var method = property.serializedObject.targetObject.GetType().GetMethod(attr.methodName, flag);
                if (method != null && method.GetParameters().Length == 0)
                {
                    try
                    {
                        method.Invoke(property.serializedObject.targetObject, null);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogException(ex, property.serializedObject.targetObject);
                    }
                }
            }
        }
    }
}
