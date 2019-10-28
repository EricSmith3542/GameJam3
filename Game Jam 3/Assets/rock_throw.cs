using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_throw : MonoBehaviour
{
    gameObject player;
    gameObject Worm;
    float velocity;
    float upVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if()//lookat, press to collect
        {
            //place relative to camera
            //parent to player
        }
        if()//press to throw
        {
            this.gameObject.Transform.Velocity = velocity*(player.transform.foreward) + upVelocity*(player.transform.up);
        }
    }
    void onCollision()//ground
    {
        //set worm's destination to here
    }
}
