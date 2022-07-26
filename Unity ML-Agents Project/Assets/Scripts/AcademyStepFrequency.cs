using Unity.MLAgents;
using UnityEngine;

namespace DevSlem.MLAgents
{
    public class AcademyStepFrequency : MonoBehaviour
    {
        [Min(1), SerializeField] private int fixedUpdatePerStep = 1;

        public int FixedUpdatePerStep
        {
            get => fixedUpdatePerStep;
            set => fixedUpdatePerStep = Mathf.Max(value, 1);
        }

        private int fixedUpdateCallCount;

        private void Awake()
        {
            Academy.Instance.AutomaticSteppingEnabled = false;
        }

        private void FixedUpdate()
        {
            fixedUpdateCallCount++;
            if (fixedUpdateCallCount == fixedUpdatePerStep)
            {
                fixedUpdateCallCount = 0;
                Academy.Instance.EnvironmentStep();
            }
        }
    }
}
