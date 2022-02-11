using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        print("RESET");
        print(TeleportTarget.transform.position);

        thePlayer.transform.position = TeleportTarget.transform.position;
    }
}
