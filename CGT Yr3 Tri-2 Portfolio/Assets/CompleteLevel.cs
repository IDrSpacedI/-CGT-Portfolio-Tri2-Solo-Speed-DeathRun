using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f;
        Debug.Log("Next Level");

    }

}
