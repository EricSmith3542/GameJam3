﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drag this code to the terrain

public class TerrainPlayerCollision : MonoBehaviour
{
    static bool playerTouchingTerrain = false;
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
        if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Rock")
        {
            playerTouchingTerrain = true;
            WormAI.aiState = WormAI.AIState.chase;
            print("Player entering terrain");

            if(hit.gameObject.tag == "Rock")
            {
                WormAI.rockTarget = hit.gameObject;
            }
        }

    }

    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            playerTouchingTerrain = false;
            print("Player exiting terrain");
        }

    }

    public static bool GetPlayerTouchingTerrain()
    {
        return playerTouchingTerrain;
    }
}
