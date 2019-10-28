using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;

    public enum AIState { idle, chase, tremor, attack }

    public AIState aiState = AIState.idle;

    float maxStunDistance = 10;
    public bool isLightOn = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
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
                    break;
                case AIState.tremor:
                    break;
                case AIState.attack:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
