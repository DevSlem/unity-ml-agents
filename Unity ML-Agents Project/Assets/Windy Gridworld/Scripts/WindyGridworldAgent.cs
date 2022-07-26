using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace DevSlem.MLAgents
{
    public class WindyGridworldAgent : Agent
    {
        public Transform actionArrow;
        public LineRenderer pathRenderer;
        public Vector2Int startPos;
        public Vector2Int goalPos;

        private Vector2Int currentPos;
        private List<Vector3> movementPath;
        private readonly int maxPathCount = 100;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if (pathRenderer != null)
            {
                movementPath = new List<Vector3>();
            }
        }

        // Wind force at the current position
        private Vector2Int WindForce
        {
            get
            {
                if ((currentPos.x >= 3 && currentPos.x <= 5) || currentPos.x == 8)
                {
                    return Vector2Int.up;
                }
                else if (currentPos.x >= 6 && currentPos.x <= 7)
                {
                    return 2 * Vector2Int.up;
                }
                else
                {
                    return Vector2Int.zero;
                }
            }
        }

        public override void OnEpisodeBegin()
        {
            UpdatePosition(startPos);
            // set action arrow direction to default
            actionArrow.rotation = Quaternion.identity;
            // update path renderer if possible
            movementPath?.Clear();
            UpdatePathRenderer();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            // agent current position
            sensor.AddObservation(currentPos.x);
            sensor.AddObservation(currentPos.y);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            // reached goal
            if (currentPos == goalPos)
            {
                EndEpisode();
                return;
            }

            // get an action
            int action = actions.DiscreteActions[0];
            // set movement
            Vector2Int movement = ConvertAction(action);
            // move the agent
            UpdatePosition(currentPos + WindForce + movement);
            // set the direction of Action Arrow to indicate which action is selected
            actionArrow.rotation = Quaternion.Euler(
                0f,
                0f,
                Vector2.SignedAngle(Vector2.up, movement)
            );
            // update path renderer if possible
            UpdatePathRenderer();
            // Set reward
            SetReward((currentPos == goalPos) ? 0f : -1f);
        }


        public override void Heuristic(in ActionBuffers actionsOut)
        {
            int action = -1;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                action = 0;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                action = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                action = 2;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                action = 3;
            }

            var discreteActionsOut = actionsOut.DiscreteActions;
            discreteActionsOut[0] = action;
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

        private void UpdatePosition(Vector2Int position)
        {
            position = new Vector2Int(
                Mathf.Clamp(position.x, 0, 9),
                Mathf.Clamp(position.y, 0, 6)
            );

            currentPos = position;
            transform.localPosition = (Vector2)position;
        }

        private void UpdatePathRenderer()
        {
            if (movementPath is null)
            {
                return;
            }
            movementPath.Add((Vector2)currentPos);
            if (movementPath.Count > maxPathCount)
            {
                movementPath.RemoveAt(0);
            }
            pathRenderer.positionCount = movementPath.Count;
            pathRenderer.SetPositions(movementPath.ToArray());
        }
    }

}
