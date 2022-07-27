using Unity.MLAgents;
using UnityEngine;
using System;

namespace DevSlem.MLAgents
{
    public sealed class AcademyStepControler : MonoBehaviour
    {
        public FixedUpdatePerStep fixedUpdatePerStep = new(1, 1);
        private static readonly Lazy<AcademyStepControler> lazy = new(() =>
        {
            var instance = FindObjectOfType<AcademyStepControler>();
            if (instance == null)
            {
                GameObject gameObject = new GameObject("Academy Step Controler");
                instance = gameObject.AddComponent<AcademyStepControler>();
            }

            return instance;
        });

        public static AcademyStepControler Instance => lazy.Value;

        public static bool IsInitialized => lazy.IsValueCreated;

        private AcademyStepControler() { }


        [Serializable]
        public struct FixedUpdatePerStep
        {
            [SerializeField, Min(1)] private int training;
            [SerializeField, Min(1)] private int inference;

            public FixedUpdatePerStep(int training, int inference)
            {
                this.training = Mathf.Max(training, 1);
                this.inference = Mathf.Max(inference, 1);
            }

            public int Training
            {
                get => training;
                set => training = Mathf.Max(value, 1);
            }

            public int Inference
            {
                get => inference;
                set => inference = Mathf.Max(value, 1);
            }
        }

        private bool isTraining;
        private int fixedUpdateCallCount;

        private void Awake()
        {
            if (Instance != this)
            {
                Debug.LogWarning($"{nameof(AcademyStepControler)} singleton object already exists. {gameObject.name} is going to be destroyed.");
                DestroyImmediate(this.gameObject);
                return;
            }

            isTraining = Academy.Instance.IsCommunicatorOn;
            Academy.Instance.AutomaticSteppingEnabled = false;
        }

        private void FixedUpdate()
        {
            fixedUpdateCallCount++;
            if (isTraining)
            {
                StepEnvironmentIfPossible(fixedUpdatePerStep.Training);
            }
            else
            {
                StepEnvironmentIfPossible(fixedUpdatePerStep.Inference);
            }
        }

        private void StepEnvironmentIfPossible(int fixedUpdatePerStep)
        {
            if (fixedUpdateCallCount >= fixedUpdatePerStep)
            {
                fixedUpdateCallCount = 0;
                Academy.Instance.EnvironmentStep();
            }
        }
    }
}
