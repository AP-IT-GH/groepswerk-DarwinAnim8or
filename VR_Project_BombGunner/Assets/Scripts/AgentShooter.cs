using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using System;

public class AgentShooter : Agent
{
    public Transform Target;
    public GameObject myprefab;
    private System.Random rand = new System.Random();
    private List<GameObject> bullets = new List<GameObject>();
    public Transform self;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 45 || this.transform.localPosition.y > 75 || this.transform.localPosition.x > -30 || this.transform.localPosition.x < -155)
        {
            this.transform.localPosition = new Vector3(-83, 60, -45);
            this.transform.localRotation = Quaternion.identity;
        }

        foreach (var bull in bullets)
        {
            Destroy(bull, .5f);
        }

        //self.position = new Vector3(-83, 60, -45);

        // verplaats de target naar een nieuwe willekeurige locatie 
        Target.localPosition = new Vector3((float)rand.Next(-140, -25), Target.localPosition.y, Target.localPosition.z);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie
        sensor.AddObservation(this.transform.localRotation);

    }

    public float speedMultiplier = 0.5f;
    public float rotationMultiplier = 5;
    
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2  
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        //controlSignal.y = actionBuffers.ContinuousActions[1];

        transform.Translate(controlSignal * speedMultiplier);
        //transform.Rotate(rotationMultiplier * 0.0f, actionBuffers.ContinuousActions[0], 0.0f);

        if (actionBuffers.ContinuousActions[1] == 1)
        {
            shootProjectile();
            SetReward(0.1f);
            
        }
        
        if (this.transform.localPosition.y < 45 || this.transform.localPosition.y > 75 || this.transform.localPosition.x > -30 || this.transform.localPosition.x < -155)
        {
            SetReward(-1f);
            EndEpisode();
        }
        if (GameObject.FindGameObjectWithTag("bullet"))
        {

            GameObject bullet = GameObject.FindGameObjectWithTag("bullet");
            float distanceToTarget = Vector3.Distance(bullet.transform.position, Target.localPosition);
            // target bereikt   
            if (distanceToTarget < 10f)
            {
                Debug.Log("HIT!");
                SetReward(1.0f); EndEpisode();
            }
            if (bullet.transform.position.x > 100 || bullet.transform.position.y > 100 || bullet.transform.position.z > 100)
            {
                Debug.Log("Destory episode end");
                foreach (var bull in bullets)
                {
                    Destroy(bull, .5f);
                }
                EndEpisode();
            }
        }
        
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetKey(KeyCode.Space) ? 1 : 0;
        //var discreteActionsOut = actionsOut.DiscreteActions;
        //discreteActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }
    public void shootProjectile()
    {
        var prefab = Instantiate(myprefab, new Vector3(self.localPosition.x, self.localPosition.y, self.localPosition.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w));
        prefab.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 2000);
        bullets.Add(prefab);
    }


}
