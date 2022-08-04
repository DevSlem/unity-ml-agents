using UnityEngine;

namespace DevSlem.Unity
{
    public sealed class OnValueChangedAttribute : PropertyAttribute
    {
        public readonly string methodName;

        public OnValueChangedAttribute(string methodName)
        {
            this.methodName = methodName;
        }
    }
}
