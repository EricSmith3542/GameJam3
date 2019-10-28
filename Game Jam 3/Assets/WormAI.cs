using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody rigidbody;
    private Animator anim;

    public enum AIState { idle, chase, tremor, attack }

    public AIState aiState = AIState.idle;
    public float speed = 5;
    public float tremorPauseTime = 1;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.forward * speed;
        StartCoroutine(Think());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIState.idle:
                    break;
                case AIState.chase:
                    //Worm chases when player is on terrain
                    if (TerrainPlayerCollision.GetPlayerTouchingTerrain() == true) { 
                    
                    
                    }

                    break;
                case AIState.tremor:
                    //Add tremor at current location
                    yield return new WaitForSeconds(tremorPauseTime);
                    break;
                case AIState.attack:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(aiState == AIState.idle)
        {
            Debug.Log("HERE");
            Vector3 velocity = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;
            rigidbody.velocity = -transform.forward * velocity.magnitude * speed;
        }
    }
}
