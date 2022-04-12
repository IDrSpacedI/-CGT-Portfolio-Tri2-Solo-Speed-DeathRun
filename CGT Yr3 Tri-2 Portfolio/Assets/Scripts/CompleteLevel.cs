using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    //when player walks into portal swap to next scene
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Portal");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
