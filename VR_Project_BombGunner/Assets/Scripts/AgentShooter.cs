using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using System;

public class AgentShooter : Agent
{
    public GameObject[] myTargets;
    public GameObject myprefab;
    private System.Random rand = new System.Random();
    private List<GameObject> bullets = new List<GameObject>();
    public Transform self;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 45 || this.transform.localPosition.y > 75 || this.transform.localPosition.x > -30 || this.transform.localPosition.x < -155)
        {
            this.transform.localPosition = new Vector3(0, 2, 0);
            this.transform.localRotation = Quaternion.identity;
        }
<<<<<<< Updated upstream

        foreach (var bull in bullets)
=======
        myTargets = GameObject.FindGameObjectsWithTag("Target");
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("bullet");
        if (gameObjects != null)
>>>>>>> Stashed changes
        {
            Destroy(bull, .5f);
        }

<<<<<<< Updated upstream
        //self.position = new Vector3(-83, 60, -45);

        // verplaats de target naar een nieuwe willekeurige locatie 
        Target.localPosition = new Vector3((float)rand.Next(-140, -25), Target.localPosition.y, Target.localPosition.z);
=======
        this.countdown = 0;
>>>>>>> Stashed changes
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie
        sensor.AddObservation(this.transform.localRotation);
        sensor.AddObservation(this.shot);

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

<<<<<<< Updated upstream
        if (actionBuffers.ContinuousActions[1] == 1)
        {
            shootProjectile();
            SetReward(0.1f);
            
=======
        if (actionBuffers.ContinuousActions[2] >= 1)
        {
                shot = true;
                shootProjectile();
                SetReward(0.1f);
>>>>>>> Stashed changes
        }
        
        if (this.transform.localPosition.y < 0 || this.transform.localPosition.y > 5 || this.transform.localPosition.x < -3 || this.transform.localPosition.x < 3)
        {
            SetReward(-1f);
            EndEpisode();
        }
        if (GameObject.FindGameObjectWithTag("bullet"))
        {

            GameObject bullet = GameObject.FindGameObjectWithTag("bullet");
            float distanceToTarget = Vector3.Distance(bullet.transform.position, myTargets[1].transform.localPosition);
            // target bereikt   
            if (distanceToTarget < 10f)
            {
                Debug.Log("HIT!");
                SetReward(1.0f); 
                EndEpisode();
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
<<<<<<< Updated upstream
        var prefab = Instantiate(myprefab, new Vector3(self.localPosition.x, self.localPosition.y, self.localPosition.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w));
        prefab.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 2000);
        bullets.Add(prefab);
=======
        if (shot)
        {
            SetReward(10.0f);
            var prefab = Instantiate(myprefab, new Vector3(self.localPosition.x, self.localPosition.y, self.localPosition.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w));
            prefab.GetComponent<Rigidbody>().AddForce(0, 0, 2000);
            shot = false;
        } 
>>>>>>> Stashed changes
    }


}
