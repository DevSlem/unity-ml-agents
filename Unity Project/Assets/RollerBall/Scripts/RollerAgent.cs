using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RollerAgent : Agent
{
    public Transform target;
    public float forceMultiplier = 10f;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        if (transform.localPosition.y < 0)
        {
            rigid.angularVelocity = Vector3.zero;
            rigid.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        target.localPosition = new Vector3(Random.Range(-4f, 4f), 0.5f, Random.Range(-4f, 4f));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.localPosition);
        sensor.AddObservation(transform.localPosition);

        sensor.AddObservation(rigid.velocity.x);
        sensor.AddObservation(rigid.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];
        rigid.AddForce(forceMultiplier * controlSignal);

        float distanceToTarget = Vector3.Distance(transform.localPosition, target.localPosition);

        if (distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            EndEpisode();
        }
        else if (transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionOut = actionsOut.ContinuousActions;
        continuousActionOut[0] = Input.GetAxis("Horizontal");
        continuousActionOut[1] = Input.GetAxis("Vertical");
    }
}
