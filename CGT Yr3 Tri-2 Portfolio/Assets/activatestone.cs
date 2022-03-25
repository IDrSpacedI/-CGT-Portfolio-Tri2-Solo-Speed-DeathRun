using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatestone : MonoBehaviour
{
    public Animator stone;
    public GameObject Text;

    public  void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        stone.Play("RockLift");
        Text.SetActive(true);

    }
}
