using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_throw : MonoBehaviour
{
    //gameObject player;
    //gameObject Worm;
    //float velocity;
    //float upVelocity;
    private Vector3 mOffset;
    private float mZCoord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if()//lookat, press to collect
        //{
        //    //place relative to camera
        //    //parent to player
        //}
        //if()//press to throw
        //{
        //    this.gameObject.Transform.Velocity = velocity*(player.transform.foreward) + upVelocity*(player.transform.up);
        //}
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mOffset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void onCollision()//ground
    {
        //set worm's destination to here
    }
}
