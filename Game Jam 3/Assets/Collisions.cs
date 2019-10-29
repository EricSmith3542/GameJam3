using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Boat"){
            SceneManager.LoadScene("Victory");
        }

        if(other.tag == "WormBody"){

            SceneManager.LoadScene("Death Screen");
        }
        
    }
}
