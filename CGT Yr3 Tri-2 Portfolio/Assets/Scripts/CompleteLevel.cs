using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Portal");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
