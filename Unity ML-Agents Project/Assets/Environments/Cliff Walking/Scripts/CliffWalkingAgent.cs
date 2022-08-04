using DevSlem.Unity;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace DevSlem.MLAgents
{
    public class CliffWalkingAgent : Agent
    {
        public PathRenderer pathRenderer;
        public Transform actionArrow;
        public Vector2Int start;
        public Vector2Int goal;
        public float stepReward;
        public float goalReward;
        public float cliffReachedReward;

        private Vector2Int currentPos;
        private bool pathRendererInitialized;

        private void Awake()
        {
            pathRendererInitialized = pathRenderer != null;

            Academy.Instance.AgentPreStep += MakeRequest;
        }

        private void OnDestroy()
        {
            if (Academy.IsInitialized)
            {
                Academy.Instance.AgentPreStep -= MakeRequest;
            }
        }

        private void MakeRequest(int obj)
        {
            if (currentPos == goal)
            {
                EndEpisode();
                return;
            }

            RequestDecision();
        }

        public override void OnEpisodeBegin()
        {
            if (pathRendererInitialized)
            {
                pathRenderer.Clear();
            }
            UpdatePosition(start);
            // set action arrow direction to default
            actionArrow.rotation = Quaternion.identity;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(currentPos.x);
            sensor.AddObservation(currentPos.y);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            // get an action
            int action = actions.DiscreteActions[0];
            // set movement
            Vector2Int movement = ConvertAction(action);
            // move the agent
            UpdatePosition(currentPos + movement);
            // set the direction of Action Arrow to indicate which action is selected
            actionArrow.rotation = Quaternion.Euler(
                0f,
                0f,
                Vector2.SignedAngle(Vector2.up, movement)
            );
            // set rewards
            if (ReachedCliff)
            {
                SetReward(cliffReachedReward);
                UpdatePosition(start);
            }
            else if (currentPos == goal)
            {
                SetReward(goalReward);
            }
            else
            {
                SetReward(stepReward);
            }
        }

        private bool ReachedCliff => currentPos.y == 0 && currentPos.x >= 1 && currentPos.x <= 10;

        private void UpdatePosition(Vector2Int position)
        {
            position = new Vector2Int(
                Mathf.Clamp(position.x, 0, 11),
                Mathf.Clamp(position.y, 0, 3)
            );

            currentPos = position;
            transform.localPosition = (Vector2)position;

            if (pathRendererInitialized)
            {
                pathRenderer.Add((Vector2)position);
            }
        }

        private Vector2Int ConvertAction(int action)
        {
            switch (action)
            {
                case 0:
                    return Vector2Int.up;
                case 1:
                    return Vector2Int.right;
                case 2:
                    return Vector2Int.down;
                default:
                    return Vector2Int.left;
            }
        }
    }

}
