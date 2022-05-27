using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AgentShooter : Agent
{
    public Transform Target;
    public GameObject myprefab;
    public Transform self;
    private bool shot;
    private int countdown;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 45 || this.transform.localPosition.y > 75 || this.transform.localPosition.x > -30 || this.transform.localPosition.x < -155)
        {
            this.transform.localPosition = new Vector3(-83, 60, -45);
            this.transform.localRotation = Quaternion.identity;
            
        }

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("bullet");
        if (gameObjects != null)
        {
            for (int i = 0; i > gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
        }

        this.countdown = 0;
        //self.position = new Vector3(-83, 60, -45);
        
        // verplaats de target naar een nieuwe willekeurige locatie 
        //Target.localPosition = new Vector3(Target.localPosition.x - Random.value, Target.localPosition.y, Random.value * 8 - 4);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(this.transform.localRotation);

    }

    public float speedMultiplier = 0.5f;
    public float rotationMultiplier = 5;
    
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2  
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.y = actionBuffers.ContinuousActions[1];

        //transform.Translate(controlSignal * speedMultiplier);
        transform.Rotate(rotationMultiplier * actionBuffers.ContinuousActions[0], 0.0f, 0.0f);

        if (actionBuffers.ContinuousActions[2] == 1)
        {
            Debug.Log(countdown);
            if (countdown < 3)
            {
                shootProjectile();
                SetReward(0.1f);
                countdown++;
            }
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
            if (bullet.transform.position.z > 100)
            {
                Destroy(bullet);
                EndEpisode();
            }
        }
        
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[1] = Input.GetAxis("Vertical");
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[2] = Input.GetKey(KeyCode.Space) ? 1 : 0;
        //var discreteActionsOut = actionsOut.DiscreteActions;
        //discreteActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }
    public void shootProjectile()
    {
        var prefab = Instantiate(myprefab, new Vector3(self.localPosition.x, self.localPosition.y, self.localPosition.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w));
        prefab.GetComponent<Rigidbody>().AddForce(0, 0, 2000);
    }




}
