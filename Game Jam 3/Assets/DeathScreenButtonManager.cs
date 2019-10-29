using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtonManager : MonoBehaviour
{
    //Place Death screen after main scene
    public void Restart(string restart){
        SceneManager.LoadScene("main");
    }

    public void QuitGame(){
        Application.Quit();
    }


}
