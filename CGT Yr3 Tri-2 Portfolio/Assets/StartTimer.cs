using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public GameObject Timer;


    private void Start()
    {
        Timer.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        Timer.SetActive(true);
    }
}
