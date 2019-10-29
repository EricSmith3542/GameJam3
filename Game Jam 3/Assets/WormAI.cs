using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private GameObject player;

    public enum AIState { idle, chase, tremor, attack }

    public static AIState aiState = AIState.idle;
    public static bool backToIdle = true;
    public float speed = 5;
    public float tremorPauseTime = 1;
    public float walkRadius = 5;
    public float attackRange = 5;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

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
                    Debug.Log("IDLE");
                    Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
                    randomDirection += transform.position;
                    NavMeshHit hit;
                    NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
                    Vector3 finalPosition = hit.position;
                    navMeshAgent.SetDestination(finalPosition);
                    break;
                case AIState.chase:
                    //Worm chases when player is on terrain
                    Debug.Log("CHASE");
                    navMeshAgent.SetDestination(player.transform.position);
                    float dist = Vector3.Distance(player.transform.position, transform.position);

                    if(dist < attackRange)
                    {
                        aiState = AIState.tremor;
                    }

                    break;
                case AIState.tremor:
                    Debug.Log("TREMOR");
                    //Add tremor at current location
                    yield return new WaitForSeconds(tremorPauseTime);
                    aiState = AIState.attack;
                    break;
                case AIState.attack:
                    Debug.Log("ATTACK");
                    //attack at tremor location
                    aiState = AIState.chase;
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
