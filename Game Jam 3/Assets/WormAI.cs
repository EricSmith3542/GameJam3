using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private GameObject player;
    private GameObject tremorDirt, wormBody, wormObject;
    private Renderer renderer;
    private AudioSource audio;

    public enum AIState { idle, chase, tremor, attack }

    public static AIState aiState = AIState.idle;
    public static GameObject rockTarget;
    public float speed = 5;
    public float tremorPauseTime = 1;
    public float walkRadius = 5;
    public float attackRange = 5;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        tremorDirt = GameObject.FindGameObjectWithTag("Tremor");
        wormBody = GameObject.FindGameObjectWithTag("WormBody");
        wormObject = GameObject.FindGameObjectWithTag("WormObject");

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
                    if(rockTarget == null)
                    {
                        //Worm chases when player is on terrain
                        Debug.Log("CHASE");
                        navMeshAgent.SetDestination(player.transform.position);
                        float dist = Vector3.Distance(player.transform.position, transform.position);

                        if (dist < attackRange)
                        {
                            aiState = AIState.tremor;
                        }
                    }
                    else
                    {
                        //Worm chases when player is on terrain
                        Debug.Log("ROCK CHASE");
                        navMeshAgent.SetDestination(rockTarget.transform.position);
                        float dist = Vector3.Distance(rockTarget.transform.position, transform.position);

                        if (dist < attackRange)
                        {
                            aiState = AIState.tremor;
                        }
                    }

                    break;
                case AIState.tremor:
                    Debug.Log("TREMOR");
                    //Add tremor at current location
                    navMeshAgent.isStopped = true;
                    renderer.enabled = false;

                    if(rockTarget == null)
                    {
                        tremorDirt.transform.position = player.transform.position;
                    }
                    else
                    {
                        tremorDirt.transform.position = rockTarget.transform.position;
                    }
                    tremorDirt.GetComponent<Renderer>().enabled = true;

                    yield return new WaitForSeconds(tremorPauseTime);
                    aiState = AIState.attack;
                    break;
                case AIState.attack:
                    Debug.Log("ATTACK");

                    wormObject.transform.position = tremorDirt.transform.position;
                    wormBody.GetComponent<Renderer>().enabled = true;


                    rockTarget = null;

                    audio.Play(0);
                    yield return new WaitForSeconds(1f);

                    aiState = AIState.chase;
                    tremorDirt.GetComponent<Renderer>().enabled = false;
                    wormBody.GetComponent<Renderer>().enabled = false;
                    renderer.enabled = true;
                    navMeshAgent.isStopped = false;
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
