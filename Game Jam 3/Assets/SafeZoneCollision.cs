using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            WormAI.aiState = WormAI.AIState.idle;
            print("Player entering safe zone");
        }

    }
}
